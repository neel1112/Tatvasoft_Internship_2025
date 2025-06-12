using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Services.IServices;
using Mission.Services.Services;

namespace Mission.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser( int id)
        {
            try
            {
                var res = await _userService.DeleteUser(id);
                return Ok(new ResponseResult() { Data = "User deleted successfully.", Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user." });
            }
        }


        [HttpGet]
        [Route("UserDetailList")]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _userService.GetAllUsers();
            return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
        }
    }
}
