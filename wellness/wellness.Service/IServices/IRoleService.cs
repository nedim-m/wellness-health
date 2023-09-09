using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Record;
using wellness.Model.Role;
using wellness.Model.RoleUpsertRequest;

namespace wellness.Service.IServices
{
    public interface IRoleService:ICrudService<Role,BaseSearchObject,RoleUpsertRequest, RoleUpsertRequest>
    {

    }
}
