
namespace Astaberry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public  class TblCategory
    {
       
        [Key]
        public int Categoryid { get; set; }
        [Required]
        public string Categoryname { get; set; }
        [Required]
        public string Categoryimage { get; set; }



    }
}
