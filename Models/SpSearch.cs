using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class SpSearch
    {
        public string Skucode { get; set; }
        public double Price { get; set; }
        public double OfferPrice { get; set; }
        public int SizeId { get; set; }
        public int Id { get; set; }
        public string Images { get; set; }
        public string ProductName { get; set; }
        public string ParentCode { get; set; }        
        public string CustomeUrl { get; set; }
        public string ShortDesc { get; set; }
        public int? AvgRating { get; set; }
    }
}
