using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Astaberry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Astaberry.Areas.Admin.Pages.Orders
{
    public class ShipRocketModel : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public ShipRocketModel(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public TblOrderId TblOrderId { get; set; }
        public TblBillingDetail billing { get; set; }
        public TblShippingDetail Shipping { get; set; }
        public List<SpOrderProductDetail> TblOrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(string Orderid, string Email)
        {
            DateTime timeUtc = System.DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            string date = cstTime.ToString("dd-MM-yyyy");
            string time = cstTime.ToString("HH:mm");
            List<ShipRocketOrderDetail> rocket = new List<ShipRocketOrderDetail>();
            TblOrderId = await _context.TblOrderIds.FirstOrDefaultAsync(m => m.Orderid == Orderid);
            string paymentmethod = string.Empty;
            if(TblOrderId.PaymentFrom=="COD")
            {
                paymentmethod = "COD";
            }
            else
            {
                paymentmethod = "Prepaid";
            }
            double Price = Convert.ToDouble(TblOrderId.TotalAmount);
            double actualprice = Price - 30;
                billing = await _context.TblBillingDetails.SingleOrDefaultAsync(tbl => tbl.ContactNumber == Email);
            Shipping = await _context.TblShippingDetails.SingleOrDefaultAsync(tbl => tbl.ContactNumber == Email);
                var SearchTextNames = new SqlParameter("@OrderCode", Orderid);
                TblOrderDetail = await _context.SpOrderProductDetail.FromSqlRaw("SpOrderProductDetail @OrderCode", SearchTextNames).ToListAsync();
            for (int i = 0; i < TblOrderDetail.Count; i++)
            {

                ShipRocketOrderDetail detail = new ShipRocketOrderDetail
                {
                    discount = 0,
                    hsn = 0,
                    name = TblOrderDetail[i].ProductName,
                    selling_price = Convert.ToDouble(TblOrderDetail[i].OfferPrice),
                    sku = TblOrderDetail[i].Skucode,
                    tax = Convert.ToDouble(0),
                    units = TblOrderDetail[i].qty
                };
                rocket.Add(detail);
            }
            //var client = new RestClient("https://apiv2.shiprocket.in/v1/external/auth/login")
            //{
            //    Timeout = -1
            //};
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", "{\n    \"email\": \"info@asharp.com\",\n    \"password\": \"Asharp@123\"\n}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //string authres = response.Content;

            //var optionss = new JsonSerializerOptions
            //{
            //    IncludeFields = true,
            //};
            //ShipRocketAuth auth = JsonConvert.DeserializeObject<ShipRocketAuth>(authres);
            //string authkey = auth.token;

            //var roundTrippedJson =
            //   JsonSerializer.Serialize<List<ShipRocketOrderDetail>>(rocket, optionss);

            //var clients = new RestClient("https://apiv2.shiprocket.in/v1/external/orders/create/adhoc")
            //{
            //    Timeout = -1
            //};
            //var requests = new RestRequest(Method.POST);
            //requests.AddHeader("Authorization", string.Format("Bearer {0}", authkey));
            //requests.AddHeader("Content-Type", "application/json");
            //string val = "{\n    \"order_id\": \"" + Orderid + "\",\n    \"order_date\": \"" + date + "\",\n    \"pickup_location\": \"Bawana\",\n    \"channel_id\": \"105501\",\n    \"comment\": \"Product Desc\",\n    \"reseller_name\": \"Astaberry\",\n    \"company_name\": \"" + Shipping.Name + "\",\n    \"billing_customer_name\": \"" + Shipping.Name + "\",\n    \"billing_last_name\": \"" + Shipping.LastName + "\",\n    \"billing_address\": \"" + Shipping.Address + "\",\n    \"billing_address_2\": \"" + billing.Address + "\",\n    \"billing_isd_code\": \"+91\",\n    \"billing_city\": \"" + billing.City + "\",\n    \"billing_pincode\": \"" + billing.PinCode + "\",\n    \"billing_state\": \"" + billing.State + "\",\n    \"billing_country\": \"" + billing.Country + "\",\n    \"billing_email\": \"" + billing.Emailid + "\",\n    \"billing_phone\": \"" + billing.ContactNumber + "\",\n    \"billing_alternate_phone\":\"\",\n    \"shipping_is_billing\": \"0\",\n    \"shipping_customer_name\": \"" + Shipping.Name + "\",\n    \"shipping_last_name\": \"" + Shipping.LastName + "\",\n    \"shipping_address\": \"" + Shipping.Apartment + "\",\n    \"shipping_address_2\": \"" + Shipping.Address + "\",\n    \"shipping_city\": \"" + Shipping.City + "\",\n    \"shipping_pincode\": \"" + Shipping.PinCode + "\",\n    \"shipping_country\": \"" + Shipping.Country + "\",\n    \"shipping_state\": \"" + Shipping.State + "\",\n    \"shipping_email\": \"" + Shipping.Emailid + "\",\n    \"shipping_phone\": \"" + Shipping.ContactNumber + "\",\n    \"order_items\":" + roundTrippedJson + ",\n    \"payment_method\": \""+ paymentmethod + "\",\n    \"shipping_charges\": \"30\",\n    \"giftwrap_charges\": \"0\",\n    \"transaction_charges\": \"0\",\n    \"total_discount\": \"" + TblOrderId.CouponCodeapplied + "\",\n    \"sub_total\": \"" + actualprice + "\",\n    \"length\": \"0.5\",\n    \"breadth\": \"0.5\",\n    \"height\": \"0.5\",\n    \"weight\": \"0.5\",\n    \"ewaybill_no\": \"\",\n    \"customer_gstin\": \"\"\n}";

            //requests.AddParameter("application/json", val, ParameterType.RequestBody);
            //IRestResponse responses = clients.Execute(requests);
            return Page();
            
        }
    }
}

