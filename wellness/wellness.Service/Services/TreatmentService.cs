using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Treatment;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class TreatmentService : CrudService<Model.Treatment.Treatment, Database.Treatment, BaseSearchObject, TreatmentPostRequest, TreatmentPostRequest>, ITreatmentService
    {
       
        private readonly DbWellnessContext _context;


        public TreatmentService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
           
            _context=context;
        }


        public override IQueryable<Database.Treatment> AddInclude(IQueryable<Database.Treatment> query, BaseSearchObject? search = null)
        {
            query=_context.Set<Database.Treatment>().AsQueryable().Include("Category").Include("TreatmentType");
            return base.AddInclude(query, search);
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _context.Treatments.FindAsync(id);

            if (obj != null) {
                var hasRelatedRatings = await _context.Ratings
                    .AnyAsync(r => r.TreatmentId == id);
                var hasRelatedReservations = await _context.Reservations.AnyAsync(r => r.TreatmentId==id);
                if (!hasRelatedRatings && !hasRelatedReservations) 
                {
                    _context.Treatments.Remove(obj);
                    await _context.SaveChangesAsync();
                    return true; 
                }
            }

            return false;
        }
    }
}
