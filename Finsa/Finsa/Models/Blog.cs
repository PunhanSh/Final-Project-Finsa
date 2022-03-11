using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200), Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Column(TypeName = "ntext"),Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Team"),Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
        public List<BlogToCategory> BlogToCategories { get; set; }
        [NotMapped]
        public List<int> TagsId { get; set; }
        [NotMapped]
        public List<int> CategoriesId { get; set; }

    }
}
