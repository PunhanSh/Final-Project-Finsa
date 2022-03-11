using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmHome : VmLayout
    {
        public List<Service> Services { get; set; }
        public List<Project> Projects { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Team> Teams { get; set; }
        public List<AboutSlider> AboutSliders { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
