using Mission.Entities;
using Mission.Entities.Models;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionRepository
    {
        Task<List<MissionRequestViewModel>> GetAllMissionAsync();
        Task<MissionRequestViewModel?> GetMissionById(int id);
        Task<bool> AddMission(Missions mission);
        Task<bool> DeleteMissionAsync(int missionId);

        Task<bool> UpdateMission(UpdateMissionRequestModel model);
    }
}
