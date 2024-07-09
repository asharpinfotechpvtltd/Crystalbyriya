using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class ProductDetailViewModel
    {
       
        public IEnumerable<TblImageGallery> ImageGalleries { get; set; }

        ApplicationDbContext context;
        public ProductDetailViewModel(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<TblImageGallery> GetImageGalleries(string Skucode)
        {
            return context.TblImageGalleries.Where(sku => sku.Productid == Skucode).ToList();
        }
        

        


    }

}

