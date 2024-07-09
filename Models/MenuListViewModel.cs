using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class MenuListViewModel
    {
        
        public int Id { get; set; }
        
        public string MenuName { get; set; }

        public List<CheckBoxItem> MenuList { get; set; }

        

    }
}
