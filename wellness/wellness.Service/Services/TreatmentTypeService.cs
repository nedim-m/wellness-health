using AutoMapper;
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
        public TreatmentTypeService(IMapper mapper, DbWellnessContext context) : base(mapper, context)
        {
        }
    }
}
