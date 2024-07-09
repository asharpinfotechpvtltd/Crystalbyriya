using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class ProductBySkuCode
    {
        public int Categoryid { get; set; }
        public int Stock { get; set; }
        public string Categoryname { get; set; }
        public int Subcategoryid { get; set; }
        public string SubCategoryName { get; set; }
        public string Brandname { get; set; }     
        public string ParentCode { get; set; }
        public string Skucode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double OfferPrice { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Metakeyword { get; set; }
        public string MetaDescription { get; set; }
        public string GroupName { get; set; }        
        public string IngredientsName { get; set; }
        public string Images { get; set; }
        public int TotalReviewCount { get; set; }
        public int Avgreviews { get; set; }
        public int TotalRating { get; set; }
        public double Gst { get; set; }
        
       
      
    }
}
