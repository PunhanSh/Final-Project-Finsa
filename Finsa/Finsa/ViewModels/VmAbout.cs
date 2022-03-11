using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmAbout : VmLayout
    {
        public List<Service> Services { get; set; }
        public List<AboutSlider> AboutSliders { get; set; }
    }
}
