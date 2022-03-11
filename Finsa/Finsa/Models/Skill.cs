using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required]
        public string Name { get; set; }
        public byte Percent { get; set; }
        public List<TeamToSkill> TeamToSkills { get; set; }
    }
}
