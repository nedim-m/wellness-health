using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.IServices;

namespace wellness.Controllers
{

  
    public class TreatmentTypeController : CrudController<Model.TreatmentType.TreatmentType, BaseSearchObject, Model.TreatmentType.TreatmentTypePostRequest, Model.TreatmentType.TreatmentTypePostRequest>
    {
        public TreatmentTypeController(ILogger<BaseController<Model.TreatmentType.TreatmentType, BaseSearchObject>> logger, ITreatmentTypeService service) : base(logger, service)
        {
        }
    }
}
