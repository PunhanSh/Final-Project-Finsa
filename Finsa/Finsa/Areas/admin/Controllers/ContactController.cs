using Finsa.Data;
using Finsa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Finsa.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Super Admin, Admin")]
        public IActionResult Index()
        {
            List<Contact> model = _context.Contacts.ToList();
            return View(model);
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Update(int id)
        {
            return View(_context.Contacts.Find(id));
        }
        [Authorize(Roles = "Super Admin, Admin")]


        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [Authorize(Roles = "Super Admin, Admin")]


        public IActionResult Delete(int id)
        {
            Contact contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult SendMailAll()
        {
            return View(_context.Contacts.ToList());
        }
        [HttpPost]
        public IActionResult SendMailAll(string MailText)
        {
            List<Contact> contacts = _context.Contacts.ToList();
            foreach (var item in contacts)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("codegroupsp@gmail.com", "Salam P222");
                message.To.Add(item.Mail);
                message.Body = MailText;
                message.IsBodyHtml = true;
                message.Subject = "Communication";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("codegroupsp@gmail.com", "codegroupsp2021");
                smtpClient.Send(message);
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(string MailText,int? id)
        {
                Contact contact = _context.Contacts.FirstOrDefault(p => p.Id == id);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("codegroupsp@gmail.com", "Salam P222");
                message.To.Add(contact.Mail);
                message.Body = MailText;
                message.IsBodyHtml = true;
                message.Subject = "Communication";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("codegroupsp@gmail.com", "codegroupsp2021");
                smtpClient.Send(message);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Super Admin, Admin")]

        public IActionResult Detail(int? Id)
        {
            if (Id != null)
            {
                if (_context.Contacts.Find(Id) != null)
                {
                    return View(_context.Contacts.Find(Id));
                }
                else
                {
                    TempData["MessageError"] = "Such an id does not exist";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                TempData["MessageError"] = "Id must not be null";
                return RedirectToAction("Index");
            }
        }
    }
}
