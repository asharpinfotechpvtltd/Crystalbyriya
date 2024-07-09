using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Astaberry.Models
{
  

    public class TblWishlist
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Productid { get; set; }
    
    }
}
