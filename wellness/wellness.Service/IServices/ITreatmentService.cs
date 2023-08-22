using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;

namespace wellness.Service.IServices
{
    public interface ITreatmentService:ICrudService<Model.Treatment.Treatment,BaseSearchObject,Model.Treatment.TreatmentPostRequest, Model.Treatment.TreatmentPostRequest>
    {
    }
}
