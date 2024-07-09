namespace Astaberry.Models
{
    public class SpSubcategoryProduct
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
        public int stock { get; set; }
      
    }
}