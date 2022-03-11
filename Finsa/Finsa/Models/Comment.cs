using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }



        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        [ForeignKey("CommentSelf")]
        public int CommentSelfId { get; set; }
        public CommentSelf CommentSelf { get; set; }
    }
}
