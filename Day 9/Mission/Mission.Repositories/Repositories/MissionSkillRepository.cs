using Microsoft.EntityFrameworkCore;
using Mission.Entities.Context;
using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;

namespace Mission.Repositories.Repositories
{
    public class MissionSkillRepository(MissionDbContext missionDbContext) : IMissionSkillRepository
    {
        private readonly MissionDbContext _missionDbContext = missionDbContext;

        public Task<List<MissionSkillViewModel>> GetAllMissionSkill()
        {
            return _missionDbContext.MissionSkill
                .Select(m => new MissionSkillViewModel()
                {
                    Id = m.Id,
                    Status = m.Status,
                    SkillName = m.SkillName,
                })
                .ToListAsync();
        }

        public Task<MissionSkillViewModel?> GetMissionSkillById(int missionSkillId)
        {
            return _missionDbContext.MissionSkill
                .Where(m => m.Id == missionSkillId)
                .Select(m => new MissionSkillViewModel()
                {
                    Id = m.Id,
                    Status = m.Status,
                    SkillName = m.SkillName,
                })
                .FirstOrDefaultAsync();

        }

        public async Task<bool> AddMissionSkill(MissionSkill missionSkill)
        {
            _missionDbContext.MissionSkill.Add(missionSkill);
            await _missionDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateMissionSkill(MissionSkill missionSkill)
        {
            var missionSkillExistingInDb = await _missionDbContext.MissionSkill.FindAsync(missionSkill.Id);

            if (missionSkillExistingInDb == null)
                return false;

            missionSkillExistingInDb.SkillName = missionSkill.SkillName;
            missionSkillExistingInDb.Status = missionSkill.Status;
            await _missionDbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteMissionSkill(int missionSkillId)
        {
            var missionSkillExistingInDb = await _missionDbContext.MissionSkill.FindAsync(missionSkillId);

            if (missionSkillExistingInDb == null)
                return false;

            _missionDbContext.Remove(missionSkillExistingInDb);
            await _missionDbContext.SaveChangesAsync();
            return true;

        }
    }
}
