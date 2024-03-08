using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using wellness.Model;
using wellness.Model.TreatmentType;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.IServices;



namespace wellness.Controllers
{
   
    public class TreatmentTypeController : CrudController<Model.TreatmentType.TreatmentType, BaseSearchObject, Model.TreatmentType.TreatmentTypePostRequest, Model.TreatmentType.TreatmentTypePostRequest>
    {
        private new readonly ITreatmentTypeService _service;
        public TreatmentTypeController(ILogger<BaseController<Model.TreatmentType.TreatmentType, BaseSearchObject>> logger, ITreatmentTypeService service) : base(logger, service)
        {
            _service=service;
        }

        [Authorize(Roles = "Administrator,Zaposlenik")]
        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            var response = await _service.Delete(id);
            if(response)
            return Ok(response);
            return BadRequest();
        }
        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<PagedResult<TreatmentType>> Get([FromQuery] BaseSearchObject? search = null)
        {
            return base.Get(search);
        }
        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<TreatmentType> GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<TreatmentType> Insert([FromBody] TreatmentTypePostRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<TreatmentType> Update(int id, [FromBody] TreatmentTypePostRequest update)
        {
            return base.Update(id, update);
        }

    }
}
