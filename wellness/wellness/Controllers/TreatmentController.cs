using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Treatment;
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

        [HttpDelete("{id}"), Authorize(Roles = "Administrator, Zaposlenik")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            if (response)
                return Ok(response);
            return BadRequest();
        }

        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<PagedResult<Model.Treatment.Treatment>> Get([FromQuery] BaseSearchObject? search = null)
        {
            return base.Get(search);
        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Model.Treatment.Treatment> Insert([FromBody] Model.Treatment.TreatmentPostRequest insert)
        {
            return base.Insert(insert);
        }
        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<Model.Treatment.Treatment> GetById(int id)
        {
            return base.GetById(id);
        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Treatment> Update(int id, [FromBody] TreatmentPostRequest update)
        {
            return base.Update(id, update);
        }


    }
}
