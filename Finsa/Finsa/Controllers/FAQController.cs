using Finsa.Data;
using Finsa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Controllers
{
    public class FAQController : Controller
    {
        private readonly AppDbContext _context;
        public FAQController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmFAQ model = new VmFAQ();
            model.Setting = _context.Settings.FirstOrDefault();
            model.Banner = _context.Banners.FirstOrDefault();
            model.Socials = _context.Socials.ToList();
            model.Partners = _context.Partners.ToList();
            model.PageImages = _context.PageImages.ToList();
            model.FAQs = _context.FAQs.ToList();
            return View(model);
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(VmFAQ model)
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
                TempData["Erroor"] = "Please, write data";
            }
            return RedirectToAction("Index");
        }
    }
}
