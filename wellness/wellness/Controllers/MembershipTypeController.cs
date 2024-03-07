using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.MembershipType;
using wellness.Service.IServices;

namespace wellness.Controllers
{

 
    public class MembershipTypeController : CrudController<MembershipType, BaseSearchObject, MembershipTypePostRequest, MembershipTypePostRequest>
    {
        public MembershipTypeController(ILogger<BaseController<MembershipType, BaseSearchObject>> logger, IMembershipTypeService service) : base(logger, service)
        {
        }

        [Authorize(Roles = "Administrator,Korisnik")]
        public override Task<MembershipType> GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize(Roles = "Administrator,Korisnik")]
 
        public override Task<PagedResult<MembershipType>> Get([FromQuery] BaseSearchObject? search = null)
        {
            return base.Get(search);
        }
    }
}
