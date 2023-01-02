using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DbWellnessContext _context;

        public UserService(IMapper mapper, DbWellnessContext context)
        {
            _mapper=mapper;
            _context=context;
        }

        public Task<ServiceResponse<UserResponse>> AddUserRoles(int id, string role)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UserResponse>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<UserResponse>>> GetAllUsers(string role)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<UserResponse>> GetUserById(int id)
        {
            var serviceResponse= new ServiceResponse<UserResponse>();
            var dbUser= await _context.Users.Include(x=>x.UserRoles).FirstOrDefaultAsync(c=>c.Id==id);
            var userRole =  _context.UserRoles.FirstOrDefault(x => x.UserId==id);
            string roleName =  _context.Roles.Find(userRole!.RoleId)!.Name;

            serviceResponse.Data=_mapper.Map<UserResponse>(dbUser);
            serviceResponse.Data.Role=roleName;
            return serviceResponse;
        }

        public Task<ServiceResponse<UserResponse>> UpdateUser(int id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
