using Finsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmTeam : VmLayout
    {
        public List<Team> Teams { get; set; }
        public List<Skill> Skills { get; set; }
        public Team Team { get; set; }
        public List<Project> Projects { get; set; }
    }
}
