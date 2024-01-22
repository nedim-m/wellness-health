using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class MembershipController : CrudController<Membership, BaseSearchObject, MembershipPostRequest, MembershipPostRequest>
    {
        public MembershipController(ILogger<BaseController<Membership, BaseSearchObject>> logger, IMembershipService service) : base(logger, service)
        {
        }
    }
}
