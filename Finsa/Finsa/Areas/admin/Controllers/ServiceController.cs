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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Service> model = _context.Services.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.Name != null && model.Description != null)
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
                            _context.Services.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
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
                    return View(model);
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
            return View(_context.Services.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Service model)
        {
            if (ModelState.IsValid)
            {
                if ( model.Name != null && model.Description != null)
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
                                _context.Services.Update(model);
                                _context.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                TempData["Erroor"] = "Please, less 2 MB image";
                                return View(model);
                            }
                        }
                        else
                        {
                            TempData["Erroor"] = "Please, image format";
                            return View(model);
                        }
                    }
                    else
                    {
                        _context.Services.Update(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                    return View(model);
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            Service service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Teams.Find(Id) != null)
                {
                    Service model = _context.Services.FirstOrDefault(t => t.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["ServiceError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["ServiceError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }
    }
}
