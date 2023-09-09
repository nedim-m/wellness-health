using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Role;
using wellness.Model.RoleUpsertRequest;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class RoleService : CrudService<Role, Database.Role, BaseSearchObject, RoleUpsertRequest, RoleUpsertRequest>, IRoleService
    {
        public RoleService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }
    }
}
