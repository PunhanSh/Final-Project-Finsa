using Finsa.Data;
using Finsa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        public TeamController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmTeam model = new VmTeam();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.ToList();
            model.Teams = _context.Teams.Include(ts => ts.TeamSocials).ToList();
            model.Projects = _context.Projects.Include(pi => pi.ProjectImages).ToList();

            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            if (id != null)
            {
                VmTeam model = new VmTeam();
                model.Setting = _context.Settings.FirstOrDefault();
                model.Banner = _context.Banners.FirstOrDefault();
                model.Socials = _context.Socials.ToList();
                model.Partners = _context.Partners.ToList();
                model.PageImages = _context.PageImages.ToList();
                model.Projects = _context.Projects.OrderByDescending(bc => bc.CreatedDate).Take(3).ToList();
                model.Team = _context.Teams.Include(ts => ts.TeamSocials)
                                           .Include(st => st.TeamToSkills).ThenInclude(s => s.Skill).FirstOrDefault(p => p.Id == id);
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
