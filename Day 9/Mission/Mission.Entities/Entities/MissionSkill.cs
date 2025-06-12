

using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Entities
{
    public class MissionSkill
    {
        [Key]
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string Status { get; set; }
    }
}
