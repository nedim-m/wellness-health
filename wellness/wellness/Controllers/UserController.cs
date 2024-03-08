using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Models.UserPostRequest;
using wellness.Service.IServices;
using wellness.Service.Services;

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


        [HttpPost("register"),Authorize(Roles ="Administrator,Zaposlenik")]
        public async Task<ActionResult<User>> RegisterUser(UserDesktopInsert request)
        {
            var response = await _service.RegisterUser(request);
            if (response!=null)
                return Ok(response);
            return BadRequest();

        }

        [HttpPut("{id}/update"), Authorize(Roles = "Administrator,Zaposlenik")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UserDesktopInsert request)
        {
            var response = await _service.UpdateUser(id, request);
            if (response!=null)
                return Ok(response);
            return BadRequest();

        }

        [HttpPut("{id}/update-employee"),Authorize(Roles = "Zaposlenik")]
        public async Task<ActionResult<User>> UpdateEmployee(int id, [FromBody] UserEmployeeDesktopUpdate request)
        {
            var response = await _service.UpdateEmployee(id, request);
            if (response!=null)
                return Ok(response);
            return BadRequest();

        }
        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<User> GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<User> Update(int id, [FromBody] UserPostRequest update)
        {
            return base.Update(id, update);
        }
    }
}
