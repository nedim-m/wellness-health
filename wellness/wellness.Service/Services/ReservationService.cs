using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Reservation;
using wellness.RabbitMQ;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class ReservationService : CrudService<Model.Reservation.Reservation, Database.Reservation, ReservationSearchObj, ReservationPostRequest, ReservationUpdateRequest>, IReservationService
    {
        private readonly IMapper _mapper;
        private readonly DbWellnessContext _context;
        private readonly RabbitMQService _rabbitMQService;

        public ReservationService(IMapper mapper, DbWellnessContext context, RabbitMQService rabbitMQService) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
            _rabbitMQService=rabbitMQService;
        }

        public override IQueryable<Database.Reservation> AddInclude(IQueryable<Database.Reservation> query, ReservationSearchObj? search = null)
        {
            query = query.Include("Treatment").Include("User");
            return base.AddInclude(query, search);
        }

        public override IQueryable<Database.Reservation> AddFilter(IQueryable<Database.Reservation> query, ReservationSearchObj? search = null)
        {
            if (search?.UserId != null)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            if (search?.TreatmentId != null)
            {
                query = query.Where(x => x.TreatmentId == search.TreatmentId);
            }

            if (!string.IsNullOrWhiteSpace(search?.Date))
            {
                query = query.Where(x => x.Date.StartsWith(search.Date) || x.Date.Contains(search.Date));
            }



            return base.AddFilter(query, search);
        }
        public override async Task<PagedResult<Model.Reservation.Reservation>> Get(ReservationSearchObj? search = null)
        {
            var query = _context.Set<Database.Reservation>().AsQueryable();

            PagedResult<Model.Reservation.Reservation> result = new();

            query = AddFilter(query, search);
            query = AddInclude(query, search);

            result.Count = await query.CountAsync();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = await query.ToListAsync();

            UpdateStatusForPastReservations(list);

            list = list
                    .OrderByDescending(r => r.Status == null)
                    .ThenByDescending(r => r.Status == true)
                    .ThenBy(r => TryParseDateTime(r.Date + " " + r.Time, out DateTime parsedDateTime) ? parsedDateTime : DateTime.MinValue)
                    .ToList();

            var tmp = _mapper.Map<List<Model.Reservation.Reservation>>(list);
            result.Result = tmp;

            return result;
        }



        private bool TryParseDateTime(string dateString, out DateTime parsedDateTime)
        {
            return DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime);
        }


        private void UpdateStatusForPastReservations(List<Database.Reservation> reservations)
        {
            DateTime currentDate = DateTime.Now;

            foreach (var reservation in reservations)
            {
                if (TryParseDateTime(reservation.Date + " " + reservation.Time, out DateTime parsedDateTime))
                {
                    if (parsedDateTime < currentDate && reservation.Status == null)
                    {
                        reservation.Status = false;
                    }
                }
               
            }
            _context.SaveChangesAsync();
        }

        public override async Task BeforeInsert(Database.Reservation entity, ReservationPostRequest insert)
        {
            var context = _context.Set<Database.Reservation>().AsQueryable();

            if (!TryParseDateTime(insert.Date + " " + insert.Time, out DateTime parsedInsertDate) || parsedInsertDate.Date == DateTime.Now.Date)
            {
                throw new InvalidOperationException("Cannot reserve for today or invalid date format.");
            }

            var existingReservationSameDateTime = await context.FirstOrDefaultAsync(r => r.UserId == entity.UserId && r.Date == insert.Date && r.TreatmentId == insert.TreatmentId && r.Time == insert.Time && (r.Status == true || r.Status == null));
            if (existingReservationSameDateTime != null)
            {
                throw new InvalidOperationException("User has already reserved this treatment at the specified date and time.");
            }

            var existingReservationDifferentTreatment = await context.FirstOrDefaultAsync(r => r.UserId == entity.UserId && r.Date == insert.Date && r.Time == insert.Time && r.TreatmentId != insert.TreatmentId);
            if (existingReservationDifferentTreatment != null)
            {
                throw new InvalidOperationException("User has already reserved a different treatment at the specified date and time.");
            }

            var existingReservationSameTreatmentDifferentTime = await context.FirstOrDefaultAsync(r => r.UserId == entity.UserId && r.Date == insert.Date && r.TreatmentId == insert.TreatmentId && r.Time != insert.Time && (r.Status == true || r.Status == null));
            if (existingReservationSameTreatmentDifferentTime != null)
            {
                throw new InvalidOperationException("User has already reserved this treatment at the specified date with a different time.");
            }
        }


        public override async Task<Model.Reservation.Reservation> Insert(ReservationPostRequest insert)
        {
            var set = _context.Set<Database.Reservation>();

            Database.Reservation entity = _mapper.Map<Database.Reservation>(insert);

            set.Add(entity);
            var data = new NotificationData
            {
                Status=insert.Status,
                SentFromMobile=true,
                Date=entity.Date,
                Time=entity.Time
            };

            try
            {
                await BeforeInsert(entity, insert);
                await _context.SaveChangesAsync();
                _rabbitMQService.SendNotification(data);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            return _mapper.Map<Model.Reservation.Reservation>(entity);
        }
        public override async Task<Model.Reservation.Reservation> Update(int id, ReservationUpdateRequest update)
        {
            var set = _context.Set<Database.Reservation>();

            var entity = await set.FindAsync(id)??throw new InvalidOperationException("Reservation doesnt exist!");
            _mapper.Map(update, entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error");
            }

            var user = await _context.Users.FindAsync(entity.UserId);
            var treatment = await _context.Treatments.FindAsync(entity.TreatmentId);





            var data = new NotificationData
            {
                Email=user!.Email,
                SentFromMobile=update.SentFromMobile,
                Status=update.Status,
                TretmentName=treatment!.Name,
                UserID=user!.Id,
                Date=entity.Date,
                Time=entity.Time
            };

            _rabbitMQService.SendNotification(data);

            return _mapper.Map<Model.Reservation.Reservation>(entity);
        }


    }
}
