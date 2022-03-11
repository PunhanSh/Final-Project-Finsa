using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class FAQController : Controller
    {
        private readonly AppDbContext _context;

        public FAQController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<FAQ> model = _context.FAQs.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FAQ model)
        {
            if (ModelState.IsValid)
            {
                if (model.AccordionHead != null && model.AccordionTitle != null)
                {
                    _context.FAQs.Add(model);
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
            return View(_context.FAQs.Find(id));
        }

        [HttpPost]
        public IActionResult Update(FAQ model)
        {
            if (ModelState.IsValid)
            {
                if (model.AccordionHead != null && model.AccordionTitle != null)
                {
                    _context.FAQs.Update(model);
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
            FAQ faq = _context.FAQs.Find(id);
            _context.FAQs.Remove(faq);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
