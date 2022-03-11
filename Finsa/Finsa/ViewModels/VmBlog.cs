using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmBlog : VmLayout
    {
        public List<Team> Teams { get; set; }
        public Team Team { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Blog> Blogss { get; set; }
        public List<Blog> RelatedBlogs { get; set; }
        public Blog Blog { get; set; }
        public Contact Contact { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public VmSearch vmSearch { get; set; }
        public CommentSelf CommentSelf { get; set; }
    }
}
