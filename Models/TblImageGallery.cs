//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Astaberry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TblImageGallery
    {
        [Key]
       
        public int Id { get; set; }

        [Required]        
        public string Productid { get; set; }

        [Required]
        public string Url { get; set; }
        
        [Required]
        public int Type { get; set; }


    }
}