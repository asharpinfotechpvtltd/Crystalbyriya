using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class TblConcern
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Concern { get; set; }

       
    }
}
