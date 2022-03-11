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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmService model = new VmService();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.ToList();
            model.ServicePage = _context.ServicePages.FirstOrDefault();
            model.Services = _context.Services.ToList();
            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            VmService model = new VmService();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.ToList();
            model.Services = _context.Services.ToList();
            model.Service = null;
            if (id != null)
            {
                model.Service = _context.Services.Find(id);
            }
            return View(model);
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(VmService model)
        {
            if (ModelState.IsValid)
            {
                model.Contact.CreatedDate = DateTime.Now;
                _context.Contacts.Add(model.Contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Erroor"] = "Please, write field blanks";
            }
            return RedirectToAction("Detail");
        }
    }
}
