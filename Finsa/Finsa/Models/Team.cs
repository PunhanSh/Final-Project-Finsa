using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(50), Required]
        public string Profession { get; set; }
        [Column(TypeName = "ntext"), Required]
        public string Description { get; set; }
        [MaxLength(20), Required]
        public string Phone { get; set; }
        [MaxLength(50), Required]
        public string Mail { get; set; }
        [MaxLength(100), Required]
        public string Address { get; set; }
        public List<AboutSlider> AboutSliders { get; set; }
        public List<TeamSocial> TeamSocials { get; set; }
        public List<TeamToSkill> TeamToSkills { get; set; }
        [NotMapped]
        public List<int> SkillsId { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
