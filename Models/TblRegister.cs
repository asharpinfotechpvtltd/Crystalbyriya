using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Astaberry.Models
{
    

    public class TblRegister
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double ContactNo { get; set; }

        [Required]
        public string Created { get; set; }

        

    }
}
