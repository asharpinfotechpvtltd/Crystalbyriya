using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    [NotMapped]
    public class SpCategoryList
    {
        public string Skucode { get; set; }
        public double Price { get; set; }
        public double OfferPrice { get; set; }
        public int SizeId { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public string ShortDesc { get; set; }
        public string ParentCode { get; set; }
        public int CatId { get; set; }
        public int? Review { get; set; }
        public int TotalCount { get; set; }
    }
}
