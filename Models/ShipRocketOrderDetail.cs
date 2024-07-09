using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class ShipRocketOrderDetail
    {
       
        
       
        public string name { get; set; }
       
        public string sku { get; set; }
       
        public int units { get; set; }
       
        public double selling_price { get; set; }
        public double discount { get; set; }
        public double tax { get; set; }
        public double hsn { get; set; }
        
        
    }
}
