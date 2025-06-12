using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services.Services
{
    public class MissionSkillService(IMissionSkillRepository missionSkillRepository) : IMissionSkillService
    {
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;
        public Task<bool> AddMissionSkill(MissionSkillViewModel model)
        {
            MissionSkill missionSkill = new MissionSkill()
            {
                Id = model.Id,
                Status = model.Status,
                SkillName = model.SkillName,
            };
            return _missionSkillRepository.AddMissionSkill(missionSkill);
        }

        public Task<bool> DeleteMissionSkill(int missionSkillId)
        {
            return _missionSkillRepository.DeleteMissionSkill(missionSkillId);
        }

        public Task<List<MissionSkillViewModel>> GetAllMissionSkill()
        {
            return _missionSkillRepository.GetAllMissionSkill();
        }

        public Task<MissionSkillViewModel?> GetMissionSkillById(int missionSkillId)
        {
            return _missionSkillRepository.GetMissionSkillById(missionSkillId);
        }

        public Task<bool> UpdateMissionSkill(MissionSkillViewModel model)
        {
            MissionSkill missionSkill = new MissionSkill()
            {
                Id = model.Id,
                Status = model.Status,
                SkillName = model.SkillName,
            };
            return _missionSkillRepository.UpdateMissionSkill(missionSkill);
        }
    }
}
