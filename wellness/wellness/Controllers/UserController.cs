using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Models.UserPostRequest;
using wellness.Service.IServices;

namespace wellness.Controllers
{

  
    public class UserController : CrudController<Models.User.User, UserSearchObj, UserPostRequest, UserPostRequest>
    {
        private new readonly IUserService _service;
        public UserController(ILogger<BaseController<User, UserSearchObj>> logger, IUserService service) : base(logger, service)
        {
            _service=service;
        }

        [HttpPost("reset")]
        public async Task<ActionResult> ForgotPassword([FromBody] UserForgotPassword request)
        {
            var response = await _service.ForgotPassword(request);
            if (response!=null)
                return Ok(response);
            return BadRequest();
        }
    }
}
