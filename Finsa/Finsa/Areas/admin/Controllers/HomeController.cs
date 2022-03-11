using Finsa.Data;
using Finsa.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            VmHome model = new VmHome();
            ViewBag.Blogs = _context.Blogs.ToList().Count;
            ViewBag.Teams = _context.Teams.ToList().Count;
            ViewBag.Projects = _context.Projects.ToList().Count;
            ViewBag.Services = _context.Services.ToList().Count;
            return View(model);
        }
    }
}
