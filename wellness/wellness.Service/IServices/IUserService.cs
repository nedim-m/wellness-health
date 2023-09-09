﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Models.UserPostRequest;

namespace wellness.Service.IServices
{
    public interface IUserService : ICrudService<User,UserSearchObj,UserPostRequest, UserPostRequest>
    {
        /*Task<ServiceResponse<IEnumerable<Models.User.User>>> GetAllUsers(UserSearchObj search);
        Task<ServiceResponse<Models.User.User>> GetUserById(int id);
        Task<ServiceResponse<Models.User.User>> UpdateUser(int id, Models.User.UserUpdateRequest request);
        Task<ServiceResponse<Models.User.User>> DeleteUser(int id);
        Task<ServiceResponse<Models.User.User>> AddUserRoles(int id, string role);*/

    }
}
