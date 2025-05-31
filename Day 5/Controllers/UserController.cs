using BooksApi.Dto;
using BooksApi.Entities.Entities;
using BooksApi.Helpers;
using BooksApi.Services;
using BooksApi.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwt;

        public UserController(IUserService userService, JwtHelper jwt)
        {
            _userService = userService;
            _jwt = jwt;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddUser(User user)
        {
            await _userService.AddUser(user);
            return Ok("User Added!");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] LoginReqDto dto)
        {
            var user = _userService.Login(dto.Email, dto.Password);

            if (user == null)
            {
                return NotFound("Please check your email & password!");
            }

            var token = _jwt.GetJwtToken(user);

            return Ok(new LoginResDto { Email = user.Email, Name = user.Name, Role = user.Role, Token = token });
        }
    }
}
