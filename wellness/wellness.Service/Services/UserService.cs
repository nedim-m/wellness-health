﻿using AutoMapper;
using Azure.Core;
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
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class UserService : CrudService<Models.User.User, Database.User, UserSearchObj, UserRegisterRequest, UserUpdateRequest>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly DbWellnessContext _context;


        public UserService(IMapper mapper, DbWellnessContext context) : base(mapper, context)
        {
            _mapper=mapper;
            _context=context;
        }




        public override async Task<PagedResult<Models.User.User>> Get(UserSearchObj? search = null)
        {
            var filteredEntity = _context.Set<Database.User>().AsQueryable().Include("Role");

            if (!string.IsNullOrWhiteSpace(search?.SearchName))
            {
                filteredEntity = filteredEntity.Where(x => x.FirstName.Contains(search.SearchName) || x.LastName.Contains(search.SearchName));
            }

            if (!string.IsNullOrWhiteSpace(search?.Role))
            {
                if (search.Role.Equals("notmember"))
                {
                    filteredEntity = filteredEntity.Where(x => !x.Role.Name.Equals("member") && !x.Role.Name.Equals("administrator"));
                }
                else
                {
                    filteredEntity = filteredEntity.Where(x => x.Role.Name.Equals(search.Role));
                }
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


        public override async Task<Models.User.User> Update(int id, UserUpdateRequest update)
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



            //_context.Update(userToUpdate);
            await _context.SaveChangesAsync();

            return _mapper.Map<Models.User.User>(userToUpdate);

            // return _mapper.Map<Models.User.User>(userToUpdate);
        }


        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }



    }
}
