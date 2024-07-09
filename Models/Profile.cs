using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Emailid { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public string Apartment { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PinCode { get; set; }

        public string Gst { get; set; }
        
    }
}
