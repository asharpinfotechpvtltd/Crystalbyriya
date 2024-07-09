namespace Astaberry.Models
{
    public class SpFilterProduct
    {
        public string Skucode { get; set; }
        public double Price { get; set; }
        public double OfferPrice { get; set; }
        public int SizeId { get; set; }
        public string Images { get; set; }
        public string ProductName { get; set; }
        public string ParentCode { get; set; }
        public int Categoryid { get; set; }
        public int Subcategoryid { get; set; }
        public string CustomeUrl { get; set; }
        public string ShortDesc { get; set; }
        public int AvgRating { get; set; }
        public int ID { get; set; }
        public int stock { get; set; }
    }
}