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
    public class MembershipService : CrudService<Membership, Database.Membership, MembershipSearchObj, MembershipPostRequest, MembershipPostRequest>, IMembershipService
    {
        public MembershipService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }


        public override IQueryable<Database.Membership> AddInclude(IQueryable<Database.Membership> query, MembershipSearchObj? search = null)
        {
            query=query.Include("User").Include("MemberShipType");
            return base.AddInclude(query, search);
        }

        public override IQueryable<Database.Membership> AddFilter(IQueryable<Database.Membership> query, MembershipSearchObj? search = null)
        {
            if (search?.UserId != null)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            return base.AddFilter(query, search);
        }
    }
}
