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
    public class SkillController : Controller
    {
        private readonly AppDbContext _context;

        public SkillController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Skill> model = _context.Skills.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Skill model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null)
                {
                    _context.Skills.Add(model);
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
            return View(_context.Skills.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Skill model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null)
                {
                    _context.Skills.Update(model);
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
            Skill skill = _context.Skills.Find(id);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
