using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.IServices;

namespace wellness.Controllers
{

  
    public class TreatmentController : CrudController<Model.Treatment.Treatment, BaseSearchObject, Model.Treatment.TreatmentPostRequest, Model.Treatment.TreatmentPostRequest>
    {
        public TreatmentController(ILogger<BaseController<Model.Treatment.Treatment, BaseSearchObject>> logger, ITreatmentService service) : base(logger, service)
        {
        }
    }
}
