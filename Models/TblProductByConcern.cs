using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class TblProductByConcern
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SkuCode { get; set; }
        [Required]
        public int ConcernId { get; set; }
    }
}
