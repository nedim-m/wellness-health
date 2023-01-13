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

        public Task<ServiceResponse<Models.User.User>> AddUserRoles(int id, string role)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Models.User.User>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<IEnumerable<Models.User.User>>> GetAllUsers(UserSearchObj search)
        {

            var filteredEntity =  _context.Set<Database.User>().AsQueryable().Include("Role");
            if (!string.IsNullOrWhiteSpace(search.SearchName))
            {
                filteredEntity= filteredEntity.Where(x => x.FirstName.Contains(search.SearchName)|| x.LastName.Contains(search.SearchName));
            }

            filteredEntity= filteredEntity.Where(x => x.Role.Name.Equals(search.Role));

            var list = filteredEntity.ToList();
            var serviceResponse = new ServiceResponse<IEnumerable<Models.User.User>>
            {
                Data=_mapper.Map<IList<Models.User.User>>(list),
                Success=true
            };

            return  serviceResponse;


        }

        public async Task<ServiceResponse<Models.User.User>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<Models.User.User>();
            var dbUser = await _context.Users.Include("Role").FirstOrDefaultAsync(u => u.Id==id);
            serviceResponse.Data=_mapper.Map<Models.User.User>(dbUser);
            return serviceResponse;
        }

        public Task<ServiceResponse<Models.User.User>> UpdateUser(int id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
