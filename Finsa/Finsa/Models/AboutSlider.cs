using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class AboutSlider
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500), Required]
        public string Content { get; set; }
        [ForeignKey("Team"), Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
