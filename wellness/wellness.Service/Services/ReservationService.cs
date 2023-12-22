using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Reservation;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class ReservationService : CrudService<Model.Reservation.Reservation, Database.Reservation, ReservationSearchObj, ReservationPostRequest, ReservationPostRequest>, IReservationService
    {

        private readonly IMapper _mapper;
        private readonly DbWellnessContext _context;
        public ReservationService(IMapper mapper, DbWellnessContext context) : base(mapper, context)
        {
            _mapper=mapper;
            _context=context;
        }


        public override IQueryable<Database.Reservation> AddInclude(IQueryable<Database.Reservation> query, ReservationSearchObj? search = null)
        {
            query=query.Include("Treatment").Include("User");

            return base.AddInclude(query, search);
        }


        public override IQueryable<Database.Reservation> AddFilter(IQueryable<Database.Reservation> query, ReservationSearchObj? search = null)
        {
            if (search?.TreatmentId!=null)
            {
                query = query.Where(x => x.TreatmentId==search.TreatmentId);
            }


            if (!string.IsNullOrWhiteSpace(search?.Date))
            {
                query = query.Where(x => x.Date.StartsWith(search.Date));
            }

            if (!string.IsNullOrWhiteSpace(search?.Date))
            {
                query = query.Where(x => x.Date.Contains(search.Date));
            }


            return base.AddFilter(query, search);
        }


        public override async Task<Task> BeforeInsert(Database.Reservation entity, ReservationPostRequest insert)
        {
            var context = _context.Set<Database.Reservation>().AsQueryable();
            var existingReservation = await  context.FirstOrDefaultAsync(r=>r.UserId==entity.UserId && r.Date==insert.Date && r.TreatmentId==insert.TreatmentId );
            if (existingReservation != null)
            {
                throw new InvalidOperationException("User has already reserved this treatment on the specified date.");
            }

            return  base.BeforeInsert(entity, insert);
        }

    }
}
