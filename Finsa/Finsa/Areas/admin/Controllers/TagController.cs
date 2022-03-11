using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Tag> model = _context.Tags.Include(tb => tb.TagToBlogs).ThenInclude(b => b.Blog).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null)
                {
                    _context.Tags.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            return View(_context.Tags.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Tag model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null)
                {
                    _context.Tags.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Tag tag = _context.Tags.Find(id);
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
