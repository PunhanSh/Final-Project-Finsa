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
    public class PageImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PageImageController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<PageImage> model = _context.PageImages.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PageImage model)
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
                            _context.PageImages.Add(model);
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
                    TempData["Erroor"] = "Please, choose data";

                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";

            }

            return View(model);

        }
        public IActionResult Update(int? id)
        {
            PageImage pageImage = null;
            if (id != null)
            {
                pageImage = _context.PageImages.FirstOrDefault(s => s.Id == id);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", pageImage.Image);
            }
            return View(_context.PageImages.Find(id));
        }

        [HttpPost]
        public IActionResult Update(PageImage model)
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
                            _context.PageImages.Update(model);
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
                    _context.PageImages.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
                return RedirectToAction("Update");
            }

        }
        public IActionResult Delete(int id)
        {
            PageImage pageImage = _context.PageImages.Find(id);
            _context.PageImages.Remove(pageImage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
