using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class MembershipController : CrudController<Membership, MembershipSearchObj, MembershipPostRequest, MembershipUpdateRequest>
    {
        public MembershipController(ILogger<BaseController<Membership, MembershipSearchObj>> logger, IMembershipService service) : base(logger, service)
        {
        }
    }
}
