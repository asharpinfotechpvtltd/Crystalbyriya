using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class ShipRocketAuth
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string company_id { get; set; }
        public string created_at { get; set; }
        public string token { get; set; }

    }
}
