using AutoMapper;
using System;
using System.Collections.Generic;
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

        public override  Task BeforeInsert(Database.Rating entity, RatingPostRequest insert)
        {

            

            DateTime currentDate = DateTime.Now;


            var reservation =  _context.Reservations.FindAsync(insert.ReservationId).Result;

            

            if (reservation!=null && reservation.Status==true)
            {
                var rating = _context.Ratings.Where(x=>x.ReservationId==reservation.Id);
                if (rating!=null)
                {
                    throw new InvalidOperationException("Already left rating");
                }

                DateTime parsedDateTime = DateTime.Parse(reservation.Date + " " + reservation.Time);
                if (currentDate<parsedDateTime)
                {
                    throw new InvalidOperationException("You can't review something you haven't attend!");
                }

            }
            else
            {
                throw new InvalidOperationException("You can't review something you haven't attend!");
            }

            return  base.BeforeInsert(entity, insert);
        }
    }
}
