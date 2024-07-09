using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class TblRange
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Range { get; set; }

        [Required]
        public string Image { get; set; }
        public string Url { get; set; }

    }
}
