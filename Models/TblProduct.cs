using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class TblProduct
    {   
      
        public int Id { get; set; }        
        public string Skucode { get; set; }
        public string? ParentCode { get; set; }
        public string? ProductName { get; set; }

        public double? QTY { get; set; }
        
        public double? Price { get; set; }        
        
        public string? KEYWORDS { get; set; }
        public string? PRODUCTDESCRIPTION { get; set; }
        public string? MOSTCOMMONLYASKEDQUESTIONS { get; set; }
        public string? ALTTEXT { get; set; }
        public string? PARENTURL { get; set; }
        public string? THUMBNAIL { get; set; }


    }
}
