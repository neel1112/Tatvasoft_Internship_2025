using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Services;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        [HttpGet]
        [Route("ClientSideMissionList/{userId:int}")]
        public async Task<IActionResult> GetClientSideMissionListAsync(int userId)
        {
            var res = await _missionService.GetClientSideMissionList();
            return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
        }
    }
}
