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
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmPortfolio model = new VmPortfolio();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.ToList();
            model.Projects = _context.Projects.Include(pi => pi.ProjectImages).ToList();
            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            if (id != null)
            {
                VmPortfolio model = new VmPortfolio();
                model.Setting = _context.Settings.FirstOrDefault();
                model.Banner = _context.Banners.FirstOrDefault();
                model.Socials = _context.Socials.ToList();
                model.Partners = _context.Partners.ToList();
                model.PageImages = _context.PageImages.Take(3).ToList();
                model.Projects = _context.Projects.Include(pi=>pi.ProjectImages).ToList();
                model.Project = _context.Projects.Include(p => p.ProjectImages).FirstOrDefault(p => p.Id == id);
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
