using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Rating;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class RatingService : CrudService<Model.Rating.Rating, Database.Rating, RatingSearchObj, RatingPostRequest, RatingUpdateRequest>, IRatingService
    {

        private readonly DbWellnessContext _context;

        public RatingService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
        }


        public override IQueryable<Database.Rating> AddFilter(IQueryable<Database.Rating> query, RatingSearchObj? search = null)
        {

            if (search?.ReservationId != null)
            {
                query = query.Where(x => x.ReservationId == search.ReservationId);
            }
            

            return base.AddFilter(query, search);
        }
        private bool TryParseDateTime(string dateString, out DateTime parsedDateTime)
        {
            return DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime);
        }

        public override  Task BeforeInsert(Database.Rating entity, RatingPostRequest insert)
        {



            DateTime currentDate = DateTime.UtcNow;



            var reservation =  _context.Reservations.FindAsync(insert.ReservationId).Result;



            if (reservation != null && reservation.Status == true)
            {
                var rating = _context.Ratings.Where(x => x.ReservationId == reservation.Id).FirstOrDefault();
                if (rating != null)
                {
                    throw new InvalidOperationException("Already left rating");
                }

                DateTime parsedDateTime;
                if (TryParseDateTime(reservation.Date + " " + reservation.Time, out parsedDateTime))
                {
                    if (currentDate < parsedDateTime)
                    {
                        throw new InvalidOperationException("You can't review something you haven't attended!");
                    }
                }
                else
                {
                    
                    throw new InvalidOperationException("Invalid date format");
                }
            }
            else
            {
                throw new InvalidOperationException("You can't review something you haven't attended!");
            }

            return  base.BeforeInsert(entity, insert);
        }
    }
}
