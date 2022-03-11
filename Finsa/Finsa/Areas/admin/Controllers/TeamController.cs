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
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Team> model = _context.Teams.Include(ts => ts.TeamToSkills).ThenInclude(t => t.Skill).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Skill = _context.Skills.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.Name != null && model.Profession!= null && model.Description != null && model.Phone != null && model.Mail!= null && model.Address != null)
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
                            _context.Teams.Add(model);
                            _context.SaveChanges();

                            foreach (var item in model.SkillsId)
                            {
                                TeamToSkill teamToSkill = new TeamToSkill();
                                teamToSkill.SkillId = item;
                                teamToSkill.TeamId = model.Id;
                                _context.TeamToSkills.Add(teamToSkill);
                            }
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Skill = _context.Skills.ToList();

                            return View(model);

                        }
                    }
                    else
                    {
                        ViewBag.Skill = _context.Skills.ToList();
                        TempData["Erroor"] = "Please, choose image format";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Skill = _context.Skills.ToList();
                    TempData["Erroor"] = "Please, choose data";
                }

            }
            else
            {
                ViewBag.Skill = _context.Skills.ToList();
                TempData["Erroor"] = "Please, choose data";
            }
            ViewBag.Skill = _context.Skills.ToList();

            return View(model);

        }
        public IActionResult Update(int id)
        {
            ViewBag.Skill = _context.Skills.ToList();
            return View(_context.Teams.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Team model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name != null && model.Profession != null && model.Description != null && model.Phone != null && model.Mail != null && model.Address != null)
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
                                _context.Teams.Update(model);
                                _context.SaveChanges();

                                List<TeamToSkill> teamToSkills = _context.TeamToSkills.Where(i => i.TeamId == model.Id).ToList();


                                foreach (var item in teamToSkills)
                                {
                                    _context.TeamToSkills.Remove(item);
                                }

                                foreach (var item in model.SkillsId)
                                {
                                    TeamToSkill teamToSkill = new TeamToSkill();
                                    teamToSkill.SkillId = item;
                                    teamToSkill.TeamId = model.Id;
                                    _context.TeamToSkills.Add(teamToSkill);
                                }
                                _context.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.Skill = _context.Skills.ToList();
                                TempData["Erroor"] = "Please, choose less 2 MB image";
                                return View(model);

                            }
                        }
                        else
                        {
                            ViewBag.Skill = _context.Skills.ToList();
                            TempData["Erroor"] = "Please, choose image format";
                            return View(model);
                        }
                    }
                    else
                    {
                        _context.Teams.Update(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }                    
                }
                else
                {
                    //List<TeamToSkill> teamToSkills = _context.TeamToSkills.Where(i => i.SkillId == model.Id).ToList();

                    //foreach (var item in teamToSkills)
                    //{
                    //    _context.TeamToSkills.Remove(item);
                    //}

                    //foreach (var item in model.SkillsId)
                    //{
                    //    TeamToSkill teamToSkill = new TeamToSkill();
                    //    teamToSkill.SkillId = item;
                    //    teamToSkill.TeamId = model.Id;
                    //    _context.TeamToSkills.Add(teamToSkill);
                    //}
                    ViewBag.Skill = _context.Skills.ToList();
                    TempData["Erroor"] = "Please, choose data";
                    return RedirectToAction("Update");
                }
            }
            else
            {
                ViewBag.Skill = _context.Skills.ToList();
                TempData["Erroor"] = "Please, choose data";
            }
            ViewBag.Skill = _context.Skills.ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Team team = _context.Teams.Include(w=>w.TeamSocials).Include(w=>w.AboutSliders).Include(w=>w.Blogs).Include(q=>q.TeamToSkills).FirstOrDefault(w=>w.Id==id);
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Teams.Find(Id) != null)
                {
                    Team model = _context.Teams.Include(ts => ts.TeamSocials).FirstOrDefault(t => t.Id == Id);
                    return View(model);

                }
                else
                {
                    TempData["BlogError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["BlogError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }
    }
}
