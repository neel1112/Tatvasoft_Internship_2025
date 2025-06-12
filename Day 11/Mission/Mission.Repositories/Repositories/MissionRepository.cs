using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Context;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;

namespace Mission.Repositories.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly MissionDbContext _dbContext;
        public MissionRepository(MissionDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public Task<List<MissionRequestViewModel>> GetAllMissionAsync()
        {
            return _dbContext.Missions.Where(m => !m.IsDeleted).Select(m => new MissionRequestViewModel()
            {
                Id = m.Id,
                CityId = m.CityId,
                CountryId = m.CountryId,
                EndDate = m.EndDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionSkillId = m.MissionSkillId,
                MissionThemeId = m.MissionThemeId,
                MissionThemeName = m.MissionTheme.ThemeName,
                MissionTitle = m.MissionTitle,
                StartDate = m.StartDate,
                TotalSeats = m.TotalSheets ?? 0,
            }).ToListAsync();
        }

        public async Task<MissionRequestViewModel?> GetMissionById(int id)
        {
            return await _dbContext.Missions.Where(m => m.Id == id && !m.IsDeleted).Select(m => new MissionRequestViewModel()
            {
                Id = m.Id,
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

        public async Task<List<MissionDetailResponseModel>> GetClientSideMissionList()
        {
            var dateToCompare = DateTime.Now.Date.AddDays(-1);
            return await _dbContext.Missions
                .Where(m => !m.IsDeleted)
                .Select(m => new MissionDetailResponseModel()
                {
                    Id = m.Id,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    CountryId = m.CountryId,
                    CityId = m.CityId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionSkillId = m.MissionSkillId,
                    MissionImages = m.MissionImages,
                    CountryName = m.Country.CountryName,
                    CityName = m.City.CityName,
                    MissionThemeName = m.MissionTheme.ThemeName,
                    MissionSkillName = string.Join(",", _dbContext.MissionSkills
                        .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                        .Select(ms => ms.SkillName)
                        .ToList()),
                    MissionStatus = m.RegistrationDeadLine < dateToCompare ? "Closed" : "Available",
                    MissionApplyStatus = "Apply", 
                    MissionApproveStatus = "Applied",
                    MissionDateStatus = m.EndDate <= dateToCompare ? "MissionEnd" : "MissionRunning",
                    MissionDeadLineStatus = m.RegistrationDeadLine <= dateToCompare ? "Closed" : "Running",
                    
                }).ToListAsync();
        }

        public async Task<bool> UpdateMission(MissionRequestViewModel mission)
        {
            try
            {
                var missionInDb = _dbContext.Missions.Find(mission.Id);

                if (missionInDb == null)
                    return false;

                missionInDb.MissionTitle = mission.MissionTitle;
                missionInDb.MissionDescription = mission.MissionDescription;
                missionInDb.CityId = mission.CityId;
                missionInDb.CountryId = mission.CountryId;
                missionInDb.MissionSkillId = mission.MissionSkillId;
                missionInDb.MissionThemeId = mission.MissionThemeId;
                missionInDb.MissionImages = $"{missionInDb.MissionImages},{mission.MissionImages}";
                missionInDb.StartDate = mission.StartDate;
                missionInDb.EndDate = mission.EndDate;
                missionInDb.TotalSheets = mission.TotalSeats;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteMission(int missionId)
        {
            try
            {
                var missionInDb = _dbContext.Missions.Find(missionId);

                if (missionInDb == null)
                    return false;

                missionInDb.IsDeleted = true;

               await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
