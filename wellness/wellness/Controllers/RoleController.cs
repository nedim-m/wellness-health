using wellness.Model;
using wellness.Model.Record;
using wellness.Model.Role;

using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class RoleController : BaseController<Role,BaseSearchObject>
    {
        public RoleController(ILogger<BaseController<Role, BaseSearchObject>> logger, IRoleService service) : base(logger, service)
        {
        }
    }
}
