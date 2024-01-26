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
    public class MembershipService : CrudService<Model.Membership.Membership, Database.Membership, MembershipSearchObj, MembershipPostRequest, MembershipUpdateRequest>, IMembershipService
    {
        private readonly DbWellnessContext _context;
        private readonly IMapper _mapper;
        public MembershipService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context=context;
            _mapper=mapper;
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

           DateTime currentDate = DateTime.Now;
           

            foreach (var membership in memberships)
            {
              
                    if (DateTime.Parse(membership.ExpirationDate) <currentDate)
                        membership.Status = false;
              
            }

             _context.SaveChangesAsync();
        }

        public override async Task<Model.Membership.Membership> Update(int id, MembershipUpdateRequest update)
        {
            var membershipType = await _context.MembershipTypes.FindAsync(update.MemberShipTypeId);
            DateTime currentDate = DateTime.Now;

            var membershipToUpdate = await _context.Memberships.FindAsync(id);
            if (membershipToUpdate == null)
            {
                return null;
            }

            if (DateTime.Parse(membershipToUpdate.ExpirationDate)<currentDate)
            {

                var dateToSet = currentDate.AddDays(membershipType!.Duration);
                membershipToUpdate.ExpirationDate = dateToSet.ToString("dd.MM.yyyy");
                membershipToUpdate.StartDate=currentDate.ToString("dd.MM.yyyy");
                membershipToUpdate.Status=true;


            }
            else
            {

                var dateToSet = DateTime.Parse(membershipToUpdate.ExpirationDate).AddDays(membershipType!.Duration);
                membershipToUpdate.ExpirationDate = dateToSet.ToString("dd.MM.yyyy");
                membershipToUpdate.Status=true;
            }
            





            _mapper.Map(update, membershipToUpdate);




            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Membership.Membership>(membershipToUpdate);
        }



    }
}
