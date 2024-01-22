using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class MembershipService : CrudService<Membership, Database.Membership, BaseSearchObject, MembershipPostRequest, MembershipPostRequest>, IMembershipService
    {
        public MembershipService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }


        public override IQueryable<Database.Membership> AddInclude(IQueryable<Database.Membership> query, BaseSearchObject? search = null)
        {
            query=query.Include("User").Include("MemberShipType");
            return base.AddInclude(query, search);
        }
    }
}
