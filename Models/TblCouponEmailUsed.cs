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

    public  class TblCouponEmailUsed
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public string Emailid { get; set; }
    }
}
