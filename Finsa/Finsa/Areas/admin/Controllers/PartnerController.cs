using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class PartnerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PartnerController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Partner> model = _context.Partners.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Partner model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile !=null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            _context.Partners.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Erroor"] = "Please, choose less 2 MB image";
                            return View(model);
                        }
                    }
                    else
                    {
                        TempData["Erroor"] = "Please, choose image format";
                        return View(model);
                    }
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
            return View(_context.Partners.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Partner model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }
                            model.Image = fileName;
                            _context.Partners.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Erroor"] = "Please, choose less 2 Mb image";
                            return View(model);
                        }
                    }
                    else
                    {
                        TempData["Erroor"] = "Please, choose image format";
                        return View(model);
                    }
                }
                else
                {
                    _context.Partners.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
                return RedirectToAction("Update");
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Partner partners = _context.Partners.Find(id);
            _context.Partners.Remove(partners);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
