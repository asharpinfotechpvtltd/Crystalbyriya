namespace Astaberry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TblState
    {
        
       [Key]
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
    
     
    }
}
