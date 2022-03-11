using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(50),Required]
        public string Mail { get; set; }
        [MaxLength(50)]
        public string? Phone { get; set; }
        [Column(TypeName = "ntext"),Required]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
