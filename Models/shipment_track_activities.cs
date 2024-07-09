using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class shipment_track_activities
    {
        public DateTime date { get; set; }
        public string status { get; set; }
        public string activity { get; set; }
        public string location { get; set; }
    }
}
