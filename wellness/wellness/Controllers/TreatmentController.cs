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

        private new readonly ITreatmentService _service;
        public TreatmentController(ILogger<BaseController<Model.Treatment.Treatment, BaseSearchObject>> logger, ITreatmentService service) : base(logger, service)
        {
            _service=service;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            if (response)
                return Ok(response);
            return BadRequest();
        }

    }
}
