using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class ConcernViewModel
    {
        
        public int Id { get; set; }
        
        public string Concern { get; set; }

        public IList<SelectListItem> ConcernList { get; set; }

    }
}
