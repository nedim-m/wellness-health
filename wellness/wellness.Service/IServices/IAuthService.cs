using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.User;
using wellness.Models.User;

namespace wellness.Service.IServices
{
    public interface IAuthService
    {
        Task<User> RegisterUser(UserRegisterRequest request);
        Task<AuthResponse> Login(UserLoginRequest request);
        Task<AuthResponse> RefreshToken();
    }
}
