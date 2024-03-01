using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Models.UserPostRequest;
using wellness.RabbitMQ;
using wellness.Service.Database;
using wellness.Service.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wellness.Service.Services
{
    public class UserService : CrudService<Models.User.User, Database.User, UserSearchObj, UserPostRequest, UserPostRequest>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly DbWellnessContext _context;
        private static readonly Random Random = new Random();
        private readonly MailService _mailService;

        public UserService(IMapper mapper, DbWellnessContext context, MailService mailService) : base(mapper, context)
        {
            _mapper=mapper;
            _context=context;
            _mailService=mailService;
        }




        public override async Task<PagedResult<Models.User.User>> Get(UserSearchObj? search = null)
        {
            var filteredEntity = _context.Set<Database.User>().AsQueryable().Include("Role").Include("Shift");

            if (!string.IsNullOrWhiteSpace(search?.SearchName))
            {
                filteredEntity = filteredEntity.Where(x => x.FirstName.Contains(search.SearchName) || x.LastName.Contains(search.SearchName));
            }

            if (!string.IsNullOrWhiteSpace(search?.Role))
            {
                if (search.Role.Equals("notmember"))
                {
                    filteredEntity = filteredEntity.Where(x => !x.Role.Name.Equals("Member") && !x.Role.Name.Equals("Administrator"));
                }
                else
                {
                    filteredEntity = filteredEntity.Where(x => x.Role.Name.Equals(search.Role));
                }
            }

            if (!string.IsNullOrWhiteSpace(search?.Prisutan))
            {
                if (search.Prisutan=="DA")
                    filteredEntity=filteredEntity.Where(x => x.Role.Name.Equals("Member")&& x.Prisutan==true);
                else
                    filteredEntity=filteredEntity.Where(x => x.Role.Name.Equals("Member")&& x.Prisutan!=true);

            }



            var list = await filteredEntity.ToListAsync();

            var mappedList = _mapper.Map<List<Models.User.User>>(list);

            var result = new PagedResult<Models.User.User>
            {
                Result = mappedList,
                Count = mappedList.Count
            };

            return result;
        }


        public override async Task<Models.User.User> Update(int id, UserPostRequest update)
        {
            if (update.Password.IsNullOrEmpty() && update.ConfrimPassword.IsNullOrEmpty())
            {
                update.Password="";
                update.ConfrimPassword="";
                return await base.Update(id, update);
            }


            var userToUpdate = await _context.Users.FindAsync(id);
            if (userToUpdate == null)
            {
                return null;
            }

            if (update.Password!=update.ConfrimPassword)
            {
                return null;
            }
            CreatePasswordHash(update.Password, out byte[] passwordHash, out byte[] passwordSalt);

            userToUpdate.PasswordHash= passwordHash;
            userToUpdate.PasswordSalt=passwordSalt;

            _mapper.Map(update, userToUpdate);




            await _context.SaveChangesAsync();

            return _mapper.Map<Models.User.User>(userToUpdate);

        }


        public override async Task<Models.User.User> Insert(UserPostRequest insert)
        {
            if (insert.Password!=insert.ConfrimPassword)
            {
                return null;
            }
            CreatePasswordHash(insert.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<Database.User>(insert);
            user.PasswordHash= passwordHash;
            user.PasswordSalt=passwordSalt;
            user.RoleId=insert.RoleId;
            user.ShiftId=insert.ShiftId;
            _context.Users.Add(user);



            await _context.SaveChangesAsync();




            return _mapper.Map<Models.User.User>(user);
        }








        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public async Task<string> ForgotPassword(UserForgotPassword request)
        {
          
            var filteredEntity = await _context.Set<Database.User>()
                .Where(x => x.UserName == request.UserName && x.Email == request.Email)
                .FirstOrDefaultAsync();

            if (filteredEntity != null && filteredEntity.RoleId == 3 && !request.Mobile)
            {
                
                return null;
            }
            if(filteredEntity != null && filteredEntity.RoleId != 3 && request.Mobile)
            {
                return null;
            }
            

          
            if (filteredEntity != null)
            {
        
                string password = GeneratePassword();

               
                var userToUpdate = await _context.Users.FindAsync(filteredEntity.Id);
                if (userToUpdate == null)
                {
                    
                    return null;
                }

               
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;

            
                await _context.SaveChangesAsync();

                
                string subject = "Resetiranje lozinke";
                string body = $"Poštovanje, Vaša nova lozinka za korisničko ime: {request.UserName} je uspešno postavljena. Molimo Vas da je odmah promenite. Nova lozinka: {password}. Lijep pozdrav. Wellness centar - Health.";

                _mailService.SendEmail(request.Email, subject, body);

         
                return "Iniciran je reset lozinke. Proverite svoj email za uputstva.";
            }


            return null;
        }




        public static string GeneratePassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789*#%&$!?#";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public async Task<Models.User.User?> RegisterUser(UserDesktopInsert request)
        {

            string password = GeneratePassword();
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<Database.User>(request);
            user.PasswordHash= passwordHash;
            user.PasswordSalt=passwordSalt;
            _context.Users.Add(user);



            await _context.SaveChangesAsync();


            string subject = "Vaša lozinka";
            string body = $"Poštovanje, Vaša lozinka za username: {request.UserName} je uspješno postavljena. Molimo Vas da odmah istu postavite na željenu. Nova lozinka: {password}  .Lijep pozdrav. Wellness centar - Health.";

            _mailService.SendEmail(request.Email, subject, body);



            return _mapper.Map<Models.User.User>(user);
        }

        public async Task<Models.User.User?> UpdateUser(int id, UserDesktopInsert request)
        {
            var userToUpdate = await _context.Users.FindAsync(id);


            if (userToUpdate == null)
            {
                return null;
            }

            _mapper.Map(request, userToUpdate);


            await _context.SaveChangesAsync();

            return _mapper.Map<Models.User.User>(userToUpdate);
        }


    }
}
