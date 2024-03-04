using Microsoft.AspNetCore.Authorization;
using wellness.Model;
using wellness.Model.MembershipType;
using wellness.Service.IServices;

namespace wellness.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class MembershipTypeController : CrudController<MembershipType, BaseSearchObject, MembershipTypePostRequest, MembershipTypePostRequest>
    {
        public MembershipTypeController(ILogger<BaseController<MembershipType, BaseSearchObject>> logger, IMembershipTypeService service) : base(logger, service)
        {
        }
    }
}
