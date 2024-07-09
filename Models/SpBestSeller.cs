using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class SpBestSeller
    {
        public string Skucode { get; set; }
        public double Price { get; set; }
        public double OfferPrice { get; set; }        
        public string Images { get; set; }
        public string ProductName { get; set; }
        public string ParentCode { get; set; }
        public string CustomeUrl { get; set; }
        public string ShortDesc { get; set; }
        public int AvgRating { get; set; }
        public int Stock { get; set; }


    }
}
