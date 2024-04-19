using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Model.MembershipType;
using wellness.Service.Database;
using wellness.Service.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wellness.Service.Services
{
    public class MembershipService : CrudService<Model.Membership.Membership, Database.Membership, MembershipSearchObj, MembershipPostRequest, MembershipUpdateRequest>, IMembershipService
    {
        private readonly DbWellnessContext _context;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;

        public MembershipService(IMapper mapper, Database.DbWellnessContext context, ITransactionService transactionService) : base(mapper, context)
        {
            _context=context;
            _mapper=mapper;
            _transactionService=transactionService;
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

        private async Task UpdateStatusForMembership(List<Database.Membership> memberships)
        {
            DateTime currentDate = DateTime.Now;

            foreach (var membership in memberships)
            {
                if (DateTime.TryParseExact(membership.ExpirationDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expirationDate) && expirationDate < currentDate)
                {
                    membership.Status = false;

                    var userToUpdate = await _context.Users.FindAsync(membership.UserId);
                    if (userToUpdate != null)
                    {
                        userToUpdate.Status = false;
                    }
                }
            }

            await _context.SaveChangesAsync();
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

            if (DateTime.TryParseExact(membershipToUpdate.ExpirationDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expirationDate) && expirationDate < currentDate)
            {
                var dateToSet = currentDate.AddDays(membershipType!.Duration);
                membershipToUpdate.ExpirationDate = dateToSet.ToString("dd.MM.yyyy");
                membershipToUpdate.StartDate = currentDate.ToString("dd.MM.yyyy");
                membershipToUpdate.Status = true;
            }
            else
            {
                DateTime dateToSet;
                if (DateTime.TryParseExact(membershipToUpdate.ExpirationDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateToSet))
                {
                    dateToSet = dateToSet.AddDays(membershipType!.Duration);
                    membershipToUpdate.ExpirationDate = dateToSet.ToString("dd.MM.yyyy");
                    membershipToUpdate.Status = true;
                }
            }

            _mapper.Map(update, membershipToUpdate);

            var userToUpdate = await _context.Users.FindAsync(membershipToUpdate.UserId);
            if (userToUpdate != null)
            {
                userToUpdate.Status = true;
            }

            if (update.IsDesktop == true)
            {
               await AddTransaction(update.MemberShipTypeId, membershipToUpdate.UserId);
            }


            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Membership.Membership>(membershipToUpdate);
        }

        public override async Task<Model.Membership.Membership> Insert(MembershipPostRequest insert)
        {
            var membershipType = await _context.MembershipTypes.FindAsync(insert.MemberShipTypeId);

            DateTime currentDate = DateTime.Now;
            var dateToSet = currentDate.AddDays(membershipType!.Duration);

            var membershipToInsert = new Database.Membership
            {
                StartDate=currentDate.ToString("dd.MM.yyyy"),
                ExpirationDate=dateToSet.ToString("dd.MM.yyyy"),
                Status=true,
                MemberShipTypeId=insert.MemberShipTypeId,
                UserId=insert.UserId
            };

            _context.Memberships.Add(membershipToInsert);
            var userToUpdate = _context.Users.FindAsync(insert.UserId);
            if (userToUpdate.Result != null)
            {
                userToUpdate.Result.Status = true;
            }

            if (insert.IsDesktop == true)
            {
               await AddTransaction(insert.MemberShipTypeId, insert.UserId);
            }


            await _context.SaveChangesAsync();

            

            return _mapper.Map<Model.Membership.Membership>(membershipToInsert);
        }


        private async Task AddTransaction( int membershipTypeId, int userId)
        {
            var memberhsip = await _context.MembershipTypes.FindAsync(membershipTypeId);
            decimal amount = (decimal)memberhsip!.Price;

            var transaction = new
            {
                Amount = amount,
                PaymentMethod = "Cash",
                Currency = "BAM",
                Timestamp = DateTime.Now.AddHours(1),
                MemberShipTypeId = membershipTypeId,
                UserId = userId

            };
            try
            {
                await _transactionService.SaveTransactionAsync(transaction);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transaction: {ex.Message}");
            }


        }
    }
}
