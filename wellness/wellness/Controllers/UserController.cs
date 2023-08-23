using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.IServices;

namespace wellness.Controllers
{

  
    public class UserController : CrudController<Models.User.User, UserSearchObj, UserRegisterRequest, UserUpdateRequest>
    {
        public UserController(ILogger<BaseController<User, UserSearchObj>> logger, IUserService service) : base(logger, service)
        {
        }
    }
}
