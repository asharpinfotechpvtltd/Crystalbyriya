using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class AssignUserAccess
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int MenuId { get; set; }
    }
}
