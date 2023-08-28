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
    }
}
