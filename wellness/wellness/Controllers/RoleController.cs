using Microsoft.AspNetCore.Authorization;
using wellness.Model;
using wellness.Model.Record;
using wellness.Model.Role;

using wellness.Service.IServices;

namespace wellness.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RoleController : BaseController<Role,BaseSearchObject>
    {
        public RoleController(ILogger<BaseController<Role, BaseSearchObject>> logger, IRoleService service) : base(logger, service)
        {
        }
    }
}
