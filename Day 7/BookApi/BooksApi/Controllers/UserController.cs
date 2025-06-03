using System.Threading.Tasks;
using BooksApi.Dto;
using BooksApi.Entities.Entities;
using BooksApi.Entities.Models.Request;
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
        private readonly JwtHelper _jwtHelper;

        public UserController(IUserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddUser(User user)
        {
            await _userService.AddUser(user);
            return Ok("User Added!");
        }

        [HttpPost]
        [Route("all")]
        public async Task<ActionResult> GetAllUsers(UserRequestModel model)
        {
            var data = await _userService.GetAllUserAsync(model);
            return Ok(data);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] LoginReqDto dto)
        {
            var user = _userService.Login(dto.Email, dto.Password);

            if (user == null)
            {
                return NotFound("Please check your email & password");
            }

            var token = _jwtHelper.GetJwtToken(user);

            return Ok(new LoginResDto() { Email = user.Email, Name = user.Email, Role = user.Role, Token = token });
        }
    }
}
