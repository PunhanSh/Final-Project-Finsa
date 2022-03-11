using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Blog> model = _context.Blogs.Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag)
                                             .Include(bc => bc.BlogToCategories).ThenInclude(c => c.Category)
                                             .Include(p => p.Team).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Team = _context.Teams.ToList();
            ViewBag.Tag = _context.Tags.ToList();
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.Name != null && model.Description != null && _context.Teams.Find(model.TeamId) != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            model.CreatedDate = DateTime.Now;
                            _context.Blogs.Add(model);
                            _context.SaveChanges();

                            foreach (var item in model.TagsId)
                            {
                                TagToBlog tagToBlog = new TagToBlog();
                                tagToBlog.TagId = item;
                                tagToBlog.BlogId = model.Id;
                                _context.TagToBlogs.Add(tagToBlog);
                            }

                            foreach (var item in model.CategoriesId)
                            {
                                BlogToCategory blogToCategory = new BlogToCategory();
                                blogToCategory.CategoryId = item;
                                blogToCategory.BlogId = model.Id;
                                _context.BlogToCategories.Add(blogToCategory);
                            }
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Team = _context.Teams.ToList();
                            ViewBag.Tag = _context.Tags.ToList();
                            ViewBag.Category = _context.Categories.ToList();
                            TempData["Erroor"] = "Please, choose less 2 MB image";
                            return View(model);

                        }
                    }
                    else
                    {
                        TempData["Erroor"] = "Please, choose image format";
                        ViewBag.Team = _context.Teams.ToList();
                        ViewBag.Tag = _context.Tags.ToList();
                        ViewBag.Category = _context.Categories.ToList();
                        return View(model);
                    }
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                    ViewBag.Team = _context.Teams.ToList();
                    ViewBag.Tag = _context.Tags.ToList();
                    ViewBag.Category = _context.Categories.ToList();
                    return View(model);
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
                ViewBag.Team = _context.Teams.ToList();
                ViewBag.Tag = _context.Tags.ToList();
                ViewBag.Category = _context.Categories.ToList();
                return View(model);
            }

            ViewBag.Team = _context.Teams.ToList();
            ViewBag.Tag = _context.Tags.ToList();
            ViewBag.Category = _context.Categories.ToList();

            return View(model);

        }
        public IActionResult Update(int id)
        {
            ViewBag.Team = _context.Teams.ToList();
            ViewBag.Tag = _context.Tags.ToList();
            ViewBag.Category = _context.Categories.ToList();

            return View(_context.Blogs.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Description != null && _context.Teams.Find(model.TeamId) != null)
                {
                    if (model.ImageFile != null)
                    {
                        if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                        {
                            if (model.ImageFile.Length <= 2000000)
                            {
                                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    model.ImageFile.CopyTo(stream);
                                }
                                model.Image = fileName;
                                model.CreatedDate = DateTime.Now;
                                _context.Blogs.Update(model);
                                _context.SaveChanges();

                                List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(i => i.BlogId == model.Id).ToList();
                                if (model.TagsId.Count > 0)
                                {
                                    foreach (var item in tagToBlogs)
                                    {
                                        _context.TagToBlogs.Remove(item);
                                    }
                                }
                                foreach (var item in model.TagsId)
                                {
                                    TagToBlog tagToBlog = new TagToBlog();
                                    tagToBlog.TagId = item;
                                    tagToBlog.BlogId = model.Id;
                                    _context.TagToBlogs.Add(tagToBlog);
                                }

                                List<BlogToCategory> blogToCategories = _context.BlogToCategories.Where(i => i.BlogId == model.Id).ToList();
                                if (model.CategoriesId.Count > 0)
                                {
                                    foreach (var item in blogToCategories)
                                    {
                                        _context.BlogToCategories.Remove(item);
                                    }
                                }
                                foreach (var item in model.CategoriesId)
                                {
                                    BlogToCategory blogToCategory = new BlogToCategory();
                                    blogToCategory.CategoryId = item;
                                    blogToCategory.BlogId = model.Id;
                                    _context.BlogToCategories.Add(blogToCategory);
                                }

                                _context.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                TempData["Erroor"] = "Please, choose less 2 MB image";
                                ViewBag.Team = _context.Teams.ToList();
                                ViewBag.Tag = _context.Tags.ToList();
                                ViewBag.Category = _context.Categories.ToList();
                                return View(model);
                            }
                        }
                        else
                        {
                            TempData["Erroor"] = "Please, choose image format";
                            ViewBag.Team = _context.Teams.ToList();
                            ViewBag.Tag = _context.Tags.ToList();
                            ViewBag.Category = _context.Categories.ToList();
                            return View(model);
                        }
                    }
                    else
                    {
                        ViewBag.Team = _context.Teams.ToList();
                        ViewBag.Tag = _context.Tags.ToList();
                        ViewBag.Category = _context.Categories.ToList();
                        model.CreatedDate = DateTime.Now;
                        _context.Blogs.Update(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                    ViewBag.Team = _context.Teams.ToList();
                    ViewBag.Tag = _context.Tags.ToList();
                    ViewBag.Category = _context.Categories.ToList();
                    return View(model);
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
                ViewBag.Team = _context.Teams.ToList();
                ViewBag.Tag = _context.Tags.ToList();
                ViewBag.Category = _context.Categories.ToList();
                return RedirectToAction("Update");
            }
            ViewBag.Team = _context.Teams.ToList();
            ViewBag.Tag = _context.Tags.ToList();
            ViewBag.Category = _context.Categories.ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Blog blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Blogs.Find(Id) != null)
                {
                    Blog model = _context.Blogs.Include(t=>t.Team).Include(bt => bt.BlogToCategories).ThenInclude(c=>c.Category).Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag).FirstOrDefault(t => t.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["BlogError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["BlogError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }
    }
}
