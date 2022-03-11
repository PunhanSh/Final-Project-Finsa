using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmLayout
    {
        public Setting Setting { get; set; }
        public List<Social> Socials { get; set; }
        public List<Contact> Contacts { get; set; }
        public Banner Banner { get; set; }
        public Subscribe Subscribe { get; set; }
        public List<PageImage> PageImages { get; set; }
        public List<Partner> Partners { get; set; }
    }
}
