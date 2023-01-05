using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.User;


namespace wellness.Service.IServices
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<Models.User.User>>> GetAllUsers(string role);
        Task<ServiceResponse<Models.User.User>> GetUserById(int id);
        Task<ServiceResponse<Models.User.User>> UpdateUser(int id, Models.User.UserUpdateRequest request);
        Task<ServiceResponse<Models.User.User>> DeleteUser(int id);
        Task<ServiceResponse<Models.User.User>> AddUserRoles(int id, string role);

    }
}
