using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finsa.ViewModels
{
    public class VmSearch
    {
        public int? tagId { get; set; }
        public int? catId { get; set; }
        public int? page { get; set; }
        public string searchData { get; set; }
    }
}
