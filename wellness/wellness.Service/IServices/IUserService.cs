using System;
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
        Task<string> ForgotPassword(UserForgotPassword request);
        

    }
}
