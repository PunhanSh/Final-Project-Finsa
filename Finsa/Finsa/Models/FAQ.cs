using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500), Required]
        public string AccordionHead { get; set; }
        [MaxLength(1000), Required]
        public string AccordionTitle { get; set; }
    }
}
