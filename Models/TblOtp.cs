using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class TblOtp
    {
        public int Id { get; set; }
        [Required]
        public double Mobile { get; set; }
        [Required]
        public int Otp { get; set; }
    }
}
