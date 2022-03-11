using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string MainImage { get; set; }
        [NotMapped]
        public IFormFile MainImageFile { get; set; }
        [MaxLength(50), Required]
        public string ClientsName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50),Required]
        public string Filter { get; set; }
        public List<ProjectImage> ProjectImages { get; set; }
    }
}
