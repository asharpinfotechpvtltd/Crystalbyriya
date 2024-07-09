using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class shipment_track
    {
        public int id { get; set; }
        public int awb_code { get; set; }
        public int courier_company_id { get; set; }
        public int shipment_id { get; set; }
        public int order_id { get; set; }
        public string pickup_date { get; set; }
        public string delivered_date { get; set; }
        public double weight { get; set; }
        public double packages { get; set; }
        public string current_status { get; set; }
        public string delivered_to { get; set; }
        public string destination { get; set; }
        public string consignee_name { get; set; }
        public string origin { get; set; }
        public string courier_agent_details { get; set; }
    }
}
