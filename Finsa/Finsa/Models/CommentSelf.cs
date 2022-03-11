using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class CommentSelf
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60), Required]
        public string FullName { get; set; }

        [MaxLength(50), Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        [NotMapped]
        public int BlogId { get; set; }

        [NotMapped]
        public int CommentId { get; set; }

        public List<Comment> Comment { get; set; }
    }
}
