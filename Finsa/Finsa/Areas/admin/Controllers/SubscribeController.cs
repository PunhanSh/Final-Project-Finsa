using Finsa.Data;
using Finsa.Models;
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
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Subscribe> model = _context.Subscribes.ToList();
            return View(model);
        }
        public IActionResult Update(int id)
        {
            return View(_context.Subscribes.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Subscribe model)
        {
            if (ModelState.IsValid)
            {
                _context.Subscribes.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Subscribe subscribe = _context.Subscribes.Find(id);
            _context.Subscribes.Remove(subscribe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SendMailAll()
        {
            return View(_context.Subscribes.ToList());
        }
        [HttpPost]
        public IActionResult SendMailAll(string MailText)
        {
            List<Subscribe> subscribes = _context.Subscribes.ToList();
            foreach (var item in subscribes)
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
    }
}
