using Mission.Entities.Models;

namespace Mission.Services.IServices
{
    public interface IMissionService
    {
        Task<List<MissionRequestViewModel>> GetAllMissionAsync();
        Task<MissionRequestViewModel?> GetMissionById(int id);
        Task<bool> AddMission(MissionRequestViewModel model);

        Task<List<MissionDetailResponseModel>> GetClientSideMissionList();
        Task<bool> UpdateMission(MissionRequestViewModel model);
        Task<bool> DeleteMission(int missionId);
    }
}
