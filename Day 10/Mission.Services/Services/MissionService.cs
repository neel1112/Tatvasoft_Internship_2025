using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;

namespace Mission.Services.Services
{
    public class MissionService(IMissionRepository missionRepository) : IMissionService
    {
        private readonly IMissionRepository _missionRepository = missionRepository;

        public Task<bool> AddMission(MissionRequestViewModel model)
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

            return _missionRepository.AddMission(mission);
        }

        public Task<List<MissionRequestViewModel>> GetAllMissionAsync()
        {
            return _missionRepository.GetAllMissionAsync();
        }

        public Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return _missionRepository.GetMissionById(id);
        }

        public async Task<bool> DeleteMissionAsync(int missionId)
        {
            return await _missionRepository.DeleteMissionAsync(missionId);
        }

        public async Task<bool> UpdateMission(UpdateMissionRequestModel model)
        {
            return await _missionRepository.UpdateMission(model);
        }


    }
}
