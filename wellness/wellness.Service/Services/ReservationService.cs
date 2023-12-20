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
        public ReservationService(IMapper mapper, DbWellnessContext context) : base(mapper, context)
        {

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
    }
}
