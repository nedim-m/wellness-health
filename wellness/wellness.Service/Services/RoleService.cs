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
using wellness.Service.Migrations;

namespace wellness.Service.Services
{
    public class RoleService : CrudService<Role, Database.Role, BaseSearchObject, RoleUpsertRequest, RoleUpsertRequest>, IRoleService
    {
        public RoleService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }

        public override IQueryable<Database.Role> AddFilter(IQueryable<Database.Role> query, BaseSearchObject? search = null)
        {
            query=query.Where(x => x.Id!=1 && x.Id!=3);

            return base.AddFilter(query, search);
        }
    }
}
