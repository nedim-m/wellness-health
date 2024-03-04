using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
    public class MembershipController : CrudController<Membership, MembershipSearchObj, MembershipPostRequest, MembershipUpdateRequest>
    {
        public MembershipController(ILogger<BaseController<Membership, MembershipSearchObj>> logger, IMembershipService service) : base(logger, service)
        {
        }
      
        public override Task<Membership> GetById(int id)
        {
            return base.GetById(id);
        }
       
        public override Task<Membership> Update(int id, [FromBody] MembershipUpdateRequest update)
        {
            return base.Update(id, update);
        }

        public override Task<Membership> Insert([FromBody] MembershipPostRequest insert)
        {
            return base.Insert(insert);
        }

        public override Task<PagedResult<Membership>> Get([FromQuery] MembershipSearchObj? search = null)
        {
            return base.Get(search);
        }
    }
}
