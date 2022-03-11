using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmContact : VmLayout
    {
        public List<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }
    }
}
