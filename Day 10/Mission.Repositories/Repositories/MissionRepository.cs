using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Context;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;

namespace Mission.Repositories.Repositories
{
    public class MissionRepository(MissionDbContext dbContext) : IMissionRepository
    {
        private readonly MissionDbContext _dbContext = dbContext;

        public Task<List<MissionRequestViewModel>> GetAllMissionAsync()
        {
            return _dbContext.Missions.Select(m => new MissionRequestViewModel()
            {
                CityId = m.CityId,
                CountryId = m.CountryId,
                EndDate = m.EndDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionSkillId = m.MissionSkillId,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                TotalSeats = m.TotalSheets ?? 0,
            }).ToListAsync();
        }

        public async Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return await _dbContext.Missions.Where(m => m.Id == id).Select(m => new MissionRequestViewModel()
            {
                CityId = m.CityId,
                CountryId = m.CountryId,
                EndDate = m.EndDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionSkillId = m.MissionSkillId,
                MissionThemeId = m.MissionThemeId,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                TotalSeats = m.TotalSheets ?? 0,
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> AddMission(Missions mission)
        {
            try
            {
                _dbContext.Missions.Add(mission);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteMissionAsync(int missionId)
        {
            var mission = await _dbContext.Missions.FindAsync(missionId);
            if (mission == null)
                return false;

            _dbContext.Missions.Remove(mission);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMission(UpdateMissionRequestModel model)
        {
            var mission = await _dbContext.Missions.FindAsync(model.MissionId);
            if (mission == null) return false;

            mission.MissionTitle = model.MissionTitle;
            mission.MissionDescription = model.MissionDescription;
            mission.StartDate = model.StartDate;
            mission.EndDate = model.EndDate;
            // Update any additional fields...

            _dbContext.Missions.Update(mission);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
