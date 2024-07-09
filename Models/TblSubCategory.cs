using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class TblSubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        [Required]
        public int Cateoryid { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
    }
}
