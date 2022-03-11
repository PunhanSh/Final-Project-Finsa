using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [MaxLength(20), Required]
        public string Phone { get; set; }
        [MaxLength(50), Required]
        public string Mail { get; set; }
        [MaxLength(100), Required]
        public string Address { get; set; }
        [MaxLength(100), Required]
        public string CopyrightLink { get; set; }
        [MaxLength(1000), Required]
        public string Map { get; set; }
        [MaxLength(500), Required]
        public string ContactText { get; set; }
        [MaxLength(500), Required]
        public string FAQText { get; set; }
        [MaxLength(100), Required]
        public string VideoLink { get; set; }
        [MaxLength(100), Required]
        public string VideoLink2 { get; set; }
        [MaxLength(100), Required]
        public string ServiceVideo { get; set; }


    }
}
