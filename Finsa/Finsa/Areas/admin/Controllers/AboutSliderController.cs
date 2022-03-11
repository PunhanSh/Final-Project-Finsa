using Finsa.Data;
using Finsa.Models;
using Finsa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutSliderController : Controller
    {
        private readonly AppDbContext _context;

        public AboutSliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<AboutSlider> model = _context.AboutSliders.Include(t => t.Team).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Team = _context.Teams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(AboutSlider model)
        {
            if (ModelState.IsValid)
            {
                if (model.Content != null && _context.Teams.Find(model.TeamId) != null)
                {
                    _context.AboutSliders.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Team = _context.Teams.ToList();

                    TempData["Erroor"] = "Please, choose data";
                }
            }
            else
            {
                ViewBag.Team = _context.Teams.ToList();

                TempData["Erroor"] = "Please, choose data";
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            ViewBag.Team = _context.Teams.ToList();
            return View(_context.AboutSliders.Find(id));
        }

        [HttpPost]
        public IActionResult Update(AboutSlider model)
        {
            if (ModelState.IsValid)
            {
                if (model.Content != null && _context.Teams.Find(model.TeamId) != null)
                {
                    _context.AboutSliders.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Team = _context.Teams.ToList();

                    TempData["Erroor"] = "Please, choose data";
                }
            }
            else
            {
                ViewBag.Team = _context.Teams.ToList();

                TempData["Erroor"] = "Please, choose data";
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            AboutSlider aboutSlider = _context.AboutSliders.Find(id);
            _context.AboutSliders.Remove(aboutSlider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
