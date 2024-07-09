namespace Astaberry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TblCustomerOrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderCode { get; set; }
        [Required]
        public string SkuCode { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Status { get; set; }
        public double? Gst { get; set; }
        

    }
}
