using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class TeamSocial
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20),Required]
        public string Name { get; set; }
        [MaxLength(100),Required]
        public string Link { get; set; }
        [MaxLength(30), Required]
        public string Icon { get; set; }
        [ForeignKey("Team"), Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
