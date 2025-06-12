using System.Net;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;

namespace Mission.Services.Services
{
    public class MissionService(IMissionRepository missionRepository) : IMissionService
    {
        private readonly IMissionRepository _missionRepository = missionRepository;

        public async Task<bool> AddMission(MissionRequestViewModel model)
        {
            var mission = new Entities.Missions()
            {
                CityId = model.CityId,
                CountryId = model.CountryId,
                EndDate = model.EndDate,
                MissionDescription = model.MissionDescription,
                MissionImages = model.MissionImages,
                MissionSkillId = model.MissionSkillId,
                MissionThemeId = model.MissionThemeId,
                MissionTitle = model.MissionTitle,
                StartDate = model.StartDate,
                TotalSheets = model.TotalSeats,
            };

            return await _missionRepository.AddMission(mission);
        }

        public async Task<bool> DeleteMission(int missionId)
        {
            return await _missionRepository.DeleteMission(missionId);
        }

        public Task<List<MissionRequestViewModel>> GetAllMissionAsync()
        {
            return _missionRepository.GetAllMissionAsync();
        }

        public async Task<List<MissionDetailResponseModel>> GetClientSideMissionList(int userId)
        {
            return await _missionRepository.GetClientSideMissionList(userId);
        }

        public Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return _missionRepository.GetMissionById(id);
        }

        public async Task<bool> UpdateMission(MissionRequestViewModel model)
        {
            return await _missionRepository.UpdateMission(model);
        }

        public async Task<(HttpStatusCode statusCode, string message)> ApplyMission(ApplyMissionRequestModel model)
        {
            return await _missionRepository.ApplyMission(model);
        }

        public async Task<List<MissionApplicationResponseModel>> GetMissionApplicationList()
        {
            return await _missionRepository.GetMissionApplicationList();
        }

        public async Task<bool> MissionApplicationApprove(int missionApplicationId)
        {
            return await _missionRepository.MissionApplicationApprove(missionApplicationId);
        }
    }
}
