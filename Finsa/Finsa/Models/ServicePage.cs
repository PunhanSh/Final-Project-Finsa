using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class ServicePage
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(1000), Required]
        public string Description { get; set; }
        [MaxLength(100), Required]
        public string Option1 { get; set; }
        [MaxLength(100), Required]
        public string Option2 { get; set; }
        [MaxLength(100), Required]
        public string Option3 { get; set; }
        [MaxLength(30), Required]
        public string Icon1 { get; set; }
        [MaxLength(30), Required]
        public string Icon2 { get; set; }
        [MaxLength(30), Required]
        public string Icon3 { get; set; }
    }
}
