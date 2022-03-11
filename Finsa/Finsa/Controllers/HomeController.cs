using Finsa.Data;
using Finsa.Models;
using Finsa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Controller = "Home";
            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.Take(6).ToList();
            model.Blogs = _context.Blogs.OrderByDescending(bc => bc.CreatedDate).Take(3).ToList();
            model.Teams = _context.Teams.Include(ts => ts.TeamSocials).Take(8).ToList();
            model.AboutSliders = _context.AboutSliders.Include(t => t.Team).ToList();
            model.Projects = _context.Projects.OrderByDescending(bc => bc.CreatedDate).Take(6).ToList();
            model.Services = _context.Services.ToList();
            return View(model);
        }

        //Subscribe
        public IActionResult Subscribe(string email)
        {
            VmSubscribe response = new VmSubscribe();

            if (!string.IsNullOrEmpty(email))
            {
                //Ajax eyni mail gondermek
                if (_context.Subscribes.Any(s => s.Mail == email))
                {
                    response.Status1 = false;
                    return Json(response);
                }
                else
                {
                    response.Status1 = true;
                    Subscribe subscribe = new();
                    subscribe.CreatedDate = DateTime.Now;
                    subscribe.Mail = email;

                    _context.Subscribes.Add(subscribe);
                    _context.SaveChanges();

                    return Json(response);

                }
            }
            else
            {
                response.Status2 = true;
                return Json(response);
            }
        }
    }
}
