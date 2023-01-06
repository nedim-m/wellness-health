using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.IServices;

namespace wellness.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service=service;
        }

        [HttpGet,AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<User>>> Get(int id)
        {
            return Ok(await _service.GetUserById(id));
        }


        [HttpGet("GetAll"), AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<IEnumerable<User>>>> GetAllUsers(string? role, string? search)
        {
            return Ok(await _service.GetAllUsers(role,search));
        }


    }
}
