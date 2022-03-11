using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
