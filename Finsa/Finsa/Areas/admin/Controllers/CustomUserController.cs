using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class CustomUserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomUserController(AppDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            List<CustomUser> model = _context.CustomUsers.ToList();
            ViewBag.Role = _context.Roles.ToList();
            return View(model);
        }
        public IActionResult Update(string id)
        {
            CustomUser customUser = _context.CustomUsers.Find(id);
            customUser.RoleId = _context.UserRoles.Where(r => r.UserId == id).Select(ri => ri.RoleId).FirstOrDefault().ToString();
            ViewBag.Role = _context.Roles.ToList();
            return View(customUser);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomUser model)
        {
            if (ModelState.IsValid)
            {
                CustomUser customUser = _context.CustomUsers.Find(model.Id);
                customUser.Name = model.Name;
                customUser.UserName = model.Email;
                customUser.Email = model.Email;
                //customUser.PhoneNumber = model.PhoneNumber;

                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length < 3000000)
                        {
                            if (!string.IsNullOrEmpty(model.Image))
                            {
                                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }
                            }


                            string ImageName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMMMyyyy") + "-" + model.ImageFile.FileName;
                            string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", ImageName);

                            using (var Stream = new FileStream(FilePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(Stream);
                            }

                            customUser.Image = ImageName;

                        }
                        else
                        {
                            TempData["UserError2"] = "The size of the Image file must be less than 3 MB";
                            ViewBag.Roles = _context.Roles.ToList();
                            return View(model);
                        }
                    }
                    else
                    {
                        TempData["UserError2"] = "The type of Image file can only be jpeg/jpg or png";
                        ViewBag.Roles = _context.Roles.ToList();
                        return View(model);
                    }

                }


                IdentityUserRole<string> userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == model.Id);

                if (userRole != null)
                {
                    string oldRole = _context.Roles.Find(userRole.RoleId).Name;
                    await _userManager.RemoveFromRoleAsync(customUser, oldRole);
                }
                _context.SaveChanges();

                IdentityRole identityRole = _context.Roles.Find(model.RoleId);
                if (identityRole != null)
                {
                    await _userManager.AddToRoleAsync(customUser, identityRole.Name);
                }


                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roles = _context.Roles.ToList();
            return View(model);

            //_context.CustomUsers.Update(model);
            //_context.SaveChanges();
            //ViewBag.Role = _context.Roles.ToList();
            //return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    CustomUser customUser = _context.CustomUsers.Find(model.Id);
            //    customUser.Name = model.Name;
            //    customUser.Email = model.Email;
            //    IdentityUserRole<string> userRole = _context.UserRoles.FirstOrDefault(r => r.UserId == model.Id);
            //    if (userRole != null)
            //    {
            //        string oldrole = _context.Roles.Find(model.RoleId).Name;
            //        await _userManager.RemoveFromRoleAsync(customUser, oldrole);
            //    }
            //    IdentityRole identityRole = _context.Roles.Find(model.RoleId);
            //    await _userManager.AddToRoleAsync(customUser, identityRole.Name);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(model);
        }
        public IActionResult Delete(string id)
        {
            CustomUser customUser = _context.CustomUsers.Find(id);
            _context.CustomUsers.Remove(customUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
