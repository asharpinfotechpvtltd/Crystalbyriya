using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class AddToCart
    {
        public string ParentProductId
        {
            get;set;
        }
        public string ProductId
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }
        public string Image
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }

       



    }
}
