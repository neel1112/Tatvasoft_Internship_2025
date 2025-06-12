using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        [HttpPost]
        [Route("AddMission")]
        public IActionResult AddMission(MissionRequestViewModel model)
        {
            var response = _missionService.AddMission(model);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpGet]
        [Route("MissionList")]
        public async Task<IActionResult> GetAllMissionAsync()
        {
            var response = await _missionService.GetAllMissionAsync();
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpGet]
        [Route("MissionDetailById/{id:int}")]
        public async Task<IActionResult> GetMissionById(int id)
        {
            var response = await _missionService.GetMissionById(id);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var result = await _missionService.DeleteMissionAsync(id);
            if (result)
                return Ok(new { message = "Mission deleted successfully" });
            return NotFound(new { message = "Mission not found" });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMission([FromBody] UpdateMissionRequestModel model)
        {
            var result = await _missionService.UpdateMission(model);
            if (!result)
                return NotFound("Mission not found");

            return Ok("Mission updated successfully");
        }
    }
}
