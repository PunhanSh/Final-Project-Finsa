using Finsa.Data;
using Finsa.Models;
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
    public class ProjectImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectImageController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<ProjectImage> model = _context.ProjectImages.Include(p => p.Project).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Projects = _context.Projects.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectImage model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && _context.Projects.Find(model.ProjectId)!= null)
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
                            _context.ProjectImages.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Projects = _context.Projects.ToList();
                            return View(model);

                        }
                    }
                    else
                    {
                        TempData["Erroor"] = "Please, choose image format";
                        ViewBag.Projects = _context.Projects.ToList();
                        return View(model);
                    }
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                    ViewBag.Projects = _context.Projects.ToList();
                    return View(model);
                }
            }
            else
            {
                ViewBag.Projects = _context.Projects.ToList();
                return View(model);
            }

        }
        public IActionResult Update(int id)
        {
            ViewBag.Projects = _context.Projects.ToList();
            return View(_context.ProjectImages.Find(id));
        }

        [HttpPost]
        public IActionResult Update(ProjectImage model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && _context.Projects.Find(model.ProjectId) != null)
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
                            _context.ProjectImages.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Projects = _context.Projects.ToList();
                            return View(model);
                        }
                    }
                    else
                    {
                        TempData["Erroor"] = "Please, choose image format";
                        ViewBag.Projects = _context.Projects.ToList();
                        return View(model);
                    }
                }
                else
                {
                    TempData["Erroor"] = "Please, choose data";
                    ViewBag.Projects = _context.Projects.ToList();
                }
            }
            else
            {
                ViewBag.Projects = _context.Projects.ToList();
                return RedirectToAction("Update");
            }
            ViewBag.Projects = _context.Projects.ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            ProjectImage projectImage = _context.ProjectImages.Find(id);
            _context.ProjectImages.Remove(projectImage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
