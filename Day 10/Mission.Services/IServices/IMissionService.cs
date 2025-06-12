using Mission.Entities.Models;

namespace Mission.Services.IServices
{
    public interface IMissionService
    {
        Task<List<MissionRequestViewModel>> GetAllMissionAsync();
        Task<MissionRequestViewModel?> GetMissionById(int id);
        Task<bool> AddMission(MissionRequestViewModel model);
        Task<bool> DeleteMissionAsync(int missionId);

        Task<bool> UpdateMission(UpdateMissionRequestModel model);

    }
}
