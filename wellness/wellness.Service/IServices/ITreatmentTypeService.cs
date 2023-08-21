using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.TreatmentType;

namespace wellness.Service.IServices
{
    public interface ITreatmentTypeService:ICrudService<TreatmentType,BaseSearchObject, TreatmentTypePostRequest, TreatmentTypePostRequest>
    {
    }
}
