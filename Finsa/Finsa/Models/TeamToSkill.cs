using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class TeamToSkill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        [ForeignKey("Skill")]
        public int? SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
