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

    public  class TblBlog
    {
        [Key]
        public int Blogid { get; set; }
        [Required]
        public string BlogTitle { get; set; }
        [Required]
        public string Blogdescription { get; set; }
        [Required]
        public int Date { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string ThumbnailImage { get; set; }

        [Required]
        public string Image { get; set; }
        [Required]
        public string Month { get; set; }
        
        [Required]
        public int Year { get; set; }

        public string CustomUrl { get; set; }
        public string Keywords { get; set; }
    }
}
