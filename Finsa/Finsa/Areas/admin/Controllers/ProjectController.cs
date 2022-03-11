using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Index()
        {
            List<Project> model = _context.Projects.ToList();
            return View(model);
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                if (model.MainImageFile != null && model.Name != null && model.Filter != null && model.ClientsName != null)
                {
                    if (model.MainImageFile.ContentType == "image/jpeg" || model.MainImageFile.ContentType == "image/png")
                    {
                        if (model.MainImageFile.Length <= 2000000)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.MainImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.MainImageFile.CopyTo(stream);
                            }
                            model.MainImage = fileName;
                            model.CreatedDate = DateTime.Now;
                            _context.Projects.Add(model);
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
                }
            }
            else
            {
                TempData["Erroor"] = "Please, choose data";

            }

            return View(model);

        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Update(int id)
        {
            return View(_context.Projects.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Project model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Filter != null && model.ClientsName != null)
                {
                    if (model.MainImageFile != null)
                    {
                        if (model.MainImageFile.ContentType == "image/jpeg" || model.MainImageFile.ContentType == "image/png")
                        {
                            if (model.MainImageFile.Length <= 2000000)
                            {
                                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.MainImageFile.FileName;
                                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    model.MainImageFile.CopyTo(stream);
                                }
                                model.CreatedDate = DateTime.Now;
                                model.MainImage = fileName;
                                _context.Projects.Update(model);
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
                        model.CreatedDate = DateTime.Now;
                        _context.Projects.Update(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
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
                return RedirectToAction("Update");
            }

            return View(model);
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Delete(int id)
        {
            Project project = _context.Projects.Include(pi => pi.ProjectImages).FirstOrDefault(w => w.Id == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Projects.Find(Id) != null)
                {
                    Project model = _context.Projects.Include(pi => pi.ProjectImages).FirstOrDefault(t => t.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["ProjectError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["ProjectError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }
    }
}
