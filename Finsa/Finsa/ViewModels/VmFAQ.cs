using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmFAQ : VmLayout
    {
        public List<FAQ> FAQs { get; set; }
        public List<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }
    }
}
