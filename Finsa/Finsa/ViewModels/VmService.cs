using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmService : VmLayout
    {
        public ServicePage ServicePage { get; set; }
        public List<Service> Services { get; set; }
        public Service Service { get; set; }
        public Contact Contact { get; set; }
    }
}
