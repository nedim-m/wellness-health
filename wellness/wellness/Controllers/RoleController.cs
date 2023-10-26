using wellness.Model;
using wellness.Model.Record;
using wellness.Model.Role;
using wellness.Model.RoleUpsertRequest;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class RoleController : CrudController<Role, BaseSearchObject, RoleUpsertRequest, RoleUpsertRequest>
    {
        public RoleController(ILogger<BaseController<Role, BaseSearchObject>> logger, IRoleService service) : base(logger, service)
        {
        }
    }
}
