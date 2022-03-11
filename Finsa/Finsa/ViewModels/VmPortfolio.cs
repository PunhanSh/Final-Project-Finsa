using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmPortfolio : VmLayout
    {
        public List<Project> Projects { get; set; }
        public Project Project { get; set; }
    }
}
