using Finsa.Data;
using Finsa.Models;
using Finsa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(VmSearch search)
        {
            VmBlog model = new VmBlog();

            if (search == null || search.page == null || search.searchData != null || search.catId != null)
            {
                search.page = 1;
            }
            //her pagede blog sayi:
            double itemCount = 2;

            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.ToList();
            model.RelatedBlogs = _context.Blogs.Take(3).ToList();
            List<Blog> blogs = _context.Blogs.Include(bc => bc.BlogToCategories).ThenInclude(c => c.Category)
                                        .Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag)
                                        .Include(c => c.Comments)
                                        .Include(t=>t.Team).ThenInclude(ts=>ts.TeamSocials)
                                        .Where(bc => (search.catId != null ? bc.BlogToCategories.Any(tb => tb.CategoryId == search.catId) : true) && (search.tagId != null ? bc.TagToBlogs.Any(tb => tb.TagId == search.tagId) : true)
                                                                      && (search.searchData != null ? bc.Name.Contains(search.searchData) : true)).ToList();
            //Pagination 
            int PageCount = (int)Math.Ceiling(Convert.ToDecimal(blogs.Count / itemCount));
            model.Blogs = blogs.Skip(((int)search.page - 1) * (int)itemCount).Take((int)itemCount).ToList();
            ViewBag.PageCount = PageCount;
            ViewBag.ItemCount = itemCount;
            ViewBag.AllCount = blogs.Count;
            ViewBag.Page = search.page;
            model.vmSearch = search;

            model.Categories = _context.Categories.ToList();
            model.Tags = _context.Tags.ToList();
            model.Contact = _context.Contacts.FirstOrDefault();
            model.Teams = _context.Teams.Include(a => a.AboutSliders).Include(ts=>ts.TeamSocials).ToList();
            model.Team = _context.Teams.Include(ts => ts.TeamSocials).FirstOrDefault();
            return View(model);
        }
        
        
        public IActionResult Detail(int? id, VmSearch search)
        {
            if (id != null)
            {
                VmBlog model = new VmBlog();
                if (model!=null)
                {
                    model.Setting = _context.Settings.FirstOrDefault();
                    model.Banner = _context.Banners.FirstOrDefault();
                    model.Socials = _context.Socials.ToList();
                    model.Partners = _context.Partners.ToList();
                    model.PageImages = _context.PageImages.ToList();
                    model.Blogss = _context.Blogs.OrderByDescending(bc => bc.CreatedDate).Take(2).ToList();
                    model.Contact = _context.Contacts.FirstOrDefault();
                    model.Team = _context.Teams.Include(ts => ts.TeamSocials).FirstOrDefault();
                    model.Blog = _context.Blogs.Include(bc => bc.BlogToCategories).ThenInclude(c => c.Category)
                                               .Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag)
                                               .Include(c => c.Comments).ThenInclude(cs => cs.CommentSelf)
                                               //.Include(c => c.Comments)
                                               .Include(t => t.Team).ThenInclude(ts => ts.TeamSocials).FirstOrDefault(p => p.Id == id);
                    model.Categories = _context.Categories.Include(bt => bt.BlogToCategories).ThenInclude(b => b.Blog).ToList();
                    model.Tags = _context.Tags.Include(tb => tb.TagToBlogs).ThenInclude(b => b.Blog).ToList();
                    List<Blog> blogs = _context.Blogs.Include(bc => bc.BlogToCategories).ThenInclude(c => c.Category)
                                            .Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag)
                                            .Include(c => c.Comments)
                                            .Include(t => t.Team).ThenInclude(ts => ts.TeamSocials)
                                            .Where(bc => (search.catId != null ? bc.BlogToCategories.Any(tb => tb.CategoryId == search.catId) : true) && (search.tagId != null ? bc.TagToBlogs.Any(tb => tb.TagId == search.tagId) : true)
                                                                          && (search.searchData != null ? bc.Name.Contains(search.searchData) : true)).ToList();
                    model.Blogs = blogs.ToList();
                    model.vmSearch = search;
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult PostComment(CommentSelf commentSelf)
        {
            //Comment

            if (ModelState.IsValid)
            {
                _context.CommentSelves.Add(commentSelf);
                _context.SaveChanges();

                Comment comment = new();
                comment.BlogId = commentSelf.BlogId;
                comment.CommentSelfId = commentSelf.Id;
                comment.FullName = commentSelf.FullName;
                comment.Email = commentSelf.Email;
                comment.CreatedDate = DateTime.Now;
                comment.Message = commentSelf.Message;

                //Self Comment
                if (commentSelf.CommentId > 0)
                {
                    comment.ParentCommentId = commentSelf.CommentId;
                }

                _context.Comments.Add(comment);
                _context.SaveChanges();


            }

            return RedirectToAction("Detail", new { Id = commentSelf.BlogId });

        }
    }
}
