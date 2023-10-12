using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class TreatmentTypeService : CrudService<Model.TreatmentType.TreatmentType, Database.TreatmentType, BaseSearchObject, Model.TreatmentType.TreatmentTypePostRequest, Model.TreatmentType.TreatmentTypePostRequest>, ITreatmentTypeService
    {
        private readonly DbWellnessContext _context;
        public TreatmentTypeService(IMapper mapper, DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _context.TreatmentTypes.FindAsync(id);
            if (obj != null)
            {
                var hasRelatedTreatments = await _context.Treatments
                    .AnyAsync(t => t.TreatmentTypeId == id);

                if (!hasRelatedTreatments)
                {
                    _context.TreatmentTypes.Remove(obj);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

    }
}
