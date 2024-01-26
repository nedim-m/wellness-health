using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Service.Database;
using wellness.Service.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wellness.Service.Services
{
    public class MembershipService : CrudService<Model.Membership.Membership, Database.Membership, MembershipSearchObj, MembershipPostRequest, MembershipPostRequest>, IMembershipService
    {
        private readonly DbWellnessContext _context;
        public MembershipService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
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
                UpdateStatusForMembership(query.ToList()); 
            }

            return base.AddFilter(query, search);
        }

        private void UpdateStatusForMembership(List<Database.Membership> memberships)
        {
            foreach (var membership in memberships)
            {

                if (DateTime.TryParse(membership.ExpirationDate, out DateTime parsedExpDate) &&
                    DateTime.TryParse(membership.StartDate, out DateTime parsedStartDate))
                {
                    if (parsedExpDate > parsedStartDate)
                        membership.Status = false;
                }

            }

            _context.SaveChangesAsync();
        }


    }
}
