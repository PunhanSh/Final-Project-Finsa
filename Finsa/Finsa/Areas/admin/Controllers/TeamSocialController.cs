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
    public class TeamSocialController : Controller
    {
        private readonly AppDbContext _context;

        public TeamSocialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TeamSocial> model = _context.TeamSocials.Include(t=>t.Team).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Team = _context.Teams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamSocial model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Link != null && model.Icon != null && _context.Teams.Find(model.TeamId) != null)
                {
                    ViewBag.Team = _context.Teams.ToList();
                    _context.TeamSocials.Add(model);
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
            ViewBag.Team = _context.Teams.ToList();
            return View(model);

        }
        public IActionResult Update(int id)
        {
            ViewBag.Team = _context.Teams.ToList();
            return View(_context.TeamSocials.Find(id));
        }

        [HttpPost]
        public IActionResult Update(TeamSocial model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Link != null && model.Icon != null && _context.Teams.Find(model.TeamId) != null)
                {
                    ViewBag.Team = _context.Teams.ToList();
                    _context.TeamSocials.Update(model);
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
            ViewBag.Team = _context.Teams.ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            TeamSocial teamSocial = _context.TeamSocials.Find(id);
            _context.TeamSocials.Remove(teamSocial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
