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
    public class ServicePageController : Controller
    {
        private readonly AppDbContext _context;

        public ServicePageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ServicePage> model = _context.ServicePages.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicePage model)
        {
            if (ModelState.IsValid)
            {
                _context.ServicePages.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Update(int id)
        {
            return View(_context.ServicePages.Find(id));
        }

        [HttpPost]
        public IActionResult Update(ServicePage model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Description != null && model.Option1 != null && model.Option2 != null && model.Option3 != null && model.Icon1 != null && model.Icon2 != null && model.Icon3 != null)
                {
                    _context.ServicePages.Update(model);
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
            ServicePage servicePage = _context.ServicePages.Find(id);
            _context.ServicePages.Remove(servicePage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
