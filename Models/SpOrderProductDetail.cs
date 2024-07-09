using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class SpOrderProductDetail
    {
        public int Id { get; set; }
        public string Skucode { get; set; }
        public string ProductName { get; set; }
        public double OfferPrice { get; set; }
        public string Size { get; set; }       
        public int qty { get; set; }
        public double? Gst { get; set; }
        public double ProductGst { get; set; }
    }
}
