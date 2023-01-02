using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;

namespace wellness.Service.IServices
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<UserResponse>>> GetAllUsers(string role);
        Task<ServiceResponse<UserResponse>> GetUserById(int id);
        Task<ServiceResponse<UserResponse>> UpdateUser(int id, UserUpdateRequest request);
        Task<ServiceResponse<UserResponse>> DeleteUser(int id);
        Task<ServiceResponse<UserResponse>> AddUserRoles(int id, string role);

    }
}
