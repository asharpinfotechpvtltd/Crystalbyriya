using Astaberry.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public class GetOrderId
    {
        ApplicationDbContext Context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession Session => _httpContextAccessor.HttpContext.Session;
        public GetOrderId(ApplicationDbContext _context)
        {
            Context = _context;
        }

        public async Task<string> GetOrder(string EmailID, double CouponCode, double Amount,string PaymentFrom,string PaymentStatus)
        {

            DateTime timeUtc = System.DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            string date = cstTime.ToString("dd-MM-yyyy");
            string time = cstTime.ToString("HH:mm");

            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@EmailID",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = EmailID
                        },
                        new SqlParameter() {
                            ParameterName = "@Date",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = date.ToString()
                        },
                        new SqlParameter() {
                            ParameterName = "@CouponCode",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = CouponCode
                        },
                        new SqlParameter() {
                            ParameterName = "@Status",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = "Pending"
                        },
                        new SqlParameter() {
                            ParameterName = "@TotalAmount",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Amount
                        },
                        new SqlParameter() {
                            ParameterName = "@PaymentFrom",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = PaymentFrom
                        },
                        new SqlParameter() {
                            ParameterName = "@PaymentStatus",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = PaymentStatus
                        },
                        new SqlParameter() {
                            ParameterName = "@ProdID",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size=100,
                            Direction = System.Data.ParameterDirection.Output
                        }};
            await Context.Database.ExecuteSqlRawAsync("SpOrderId @EmailID,@Date,@CouponCode,@Status,@TotalAmount,@PaymentFrom,@PaymentStatus,@ProdID out", param);
            string Orderid = Convert.ToString(param[7].Value);

            return Orderid;

        }
        double Gst, GrandTotal, SubTotal, DiscountedAmount, beforediscount = 0;
        public async Task Order(string Orderid,string Date)
        {
            string Mobile = Session.GetString("mobile");          
           
            //string shipping = string.Empty;          
            string contact = "91" + Mobile;
            TblBillingDetail billing = await Context.TblBillingDetails.FirstOrDefaultAsync(m => m.ContactNumber == Mobile);
            TblShippingDetail Shipping = await Context.TblShippingDetails.FirstOrDefaultAsync(m => m.ContactNumber == Mobile);



            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(Session, "cart");
            string textBody = "<table align='center' width='100%' border='1'>" +
                "<tr><td colspan='8' align='center'><img src='https://www.astaberry.com/img/logo/logo.png' height='auto' width='150px' align='center' />ASTABERRY BIOSCIENCE (I) PVT LTD.</ td></tr>" +
                "<tr style='height:60px; background-color:#18375f;font-size:x-large;' align='center'><td colspan='8'><strong style='color:#ffffff'> Thank you for your order</strong></td></tr>" +
                "<tr style='height:30px;'> <td style='font-size:x-large;' colspan='8'> Your order has been received and is now being processed.</td></tr>" +
                "<tr><td colspan'8'><h3>Biling Address</h3></td></tr>" +
                "<tr><td colspan='2'>Customer Name:</td><td colspan='2'> " + billing.Name + "</td><td colspan='2'>Email:</td><td colspan='2'> " + billing.Emailid + "</td></tr>" +
                "<tr><td colspan='2'>Contact:</td><td colspan='2'> " + billing.ContactNumber + "</td><td colspan='2'>Address:</td><td colspan='2'> " + billing.Address + "</td></tr>" +
                "<tr><td colspan='2'>City:</td><td colspan='2'> " + billing.City + "</td><td colspan='2'>State:</td><td colspan='2'> " + billing.State + "</td></tr>" +
                "<tr><td colspan='2'>Gst:</td><td colspan='2'> " + billing.Gst + "</td><td colspan='2'>Pincode:</td><td colspan='2'> " + billing.PinCode + "</td></tr>" +
                "<tr><td colspan='8'></td></tr>" +
                "<tr><td colspan'8'><h3> Shipping Address </h3></td></tr>" +
                "<tr><td colspan='2'>Customer Name:</td><td colspan='2'>" + Shipping.Name + "</td><td colspan='2'> Email:</td><td colspan='2'> " + Shipping.Emailid + " </td></tr>" +
                                "<tr><td colspan='2'>Contact:</td><td colspan='2'>" + Shipping.ContactNumber + "</td><td colspan='2'> Address:</td><td colspan='2'> " + Shipping.Address + " </td></tr>" +
                                 "<tr><td colspan='2'> City:</td><td colspan='2'> " + Shipping.City + " </td><td colspan='2'> State:</td><td colspan='2'> " + Shipping.State + " </td></tr>" +
                                  "<tr><td colspan='2'> Gst:</td><td colspan='2'>  " + "N/A" + "</td><td colspan='2'> Pincode:</td><td colspan='2'> " + Shipping.PinCode + " </td></tr>" +
                                   "<tr><td></td><td></tr><tr><td style='font-size:x-large;' colspan='8'><b> Your Order No. Is:" + Orderid + ", Dated:" + Date + "</b></td></tr>" +
                                    "<tr bgcolor='#18375f'><td colspan='1'><b>SNo.</b></td> <td colspan='2'> <b> Image</b> </td><td colspan='2'> <b> Product Name</b> </td><td colspan='1'> <b> Qty</b> </td><td colspan='2'> <b> Price</b> </td></tr>";
            for (int i = 0; i < cart.Count; i++)
            {
                TblCustomerOrderDetail orderdetail = new TblCustomerOrderDetail
                {
                    OrderCode = Orderid,
                    SkuCode = cart[i].ProductId,
                    Qty = cart[i].Qty,
                    Price = Convert.ToDouble(cart[i].Price),
                    Status = "Pending",
                    Gst = cart[i].Gst
                };
                Context.TblCustomerOrderDetails.Add(orderdetail);
                await Context.SaveChangesAsync();
                SubTotal += Convert.ToDouble(cart[i].Qty * cart[i].Price);
                Gst += cart[i].Gst;
                textBody += "<tr><td colspan='1'>" + i + 1 + "</td><td colspan='2'> " + "<img src='https://www.astaberry.com/img/products/" + cart[i].Image + "' height='100px' width='100px'/>" + "</td><td colspan='2'>" + cart[i].ProductName + "</td><td colspan='1'>" + cart[i].Qty + "</td><td colspan='2'>" + cart[i].Price + "</td> </tr>";

            }

            string Pincode = Convert.ToString(Session.GetString("Pincode"));
            if (Session.GetString("CouponCode") != null)
            {
                DiscountedAmount = Convert.ToDouble(Session.GetString("CouponCode"));
                beforediscount = SubTotal - DiscountedAmount;
            }
            double? Total = SubTotal - Gst;
            GrandTotal = SubTotal + 30;
            double? shiprocketamt = SubTotal + 30;

            textBody += "<tr><td colspan='8' align='right'> Sub Total: Rs "
                + Math.Round(Convert.ToDouble(Total))
                + "/-</td></tr>" +
                "<tr><td colspan='8' align='right'> GST: Rs "
                + Math.Round(Convert.ToDouble(Gst))
                + "/-</td></tr>" +
            "<tr><td colspan = '8' align = 'right'> Discount: Rs "
                        + Math.Round(DiscountedAmount)
                        + "/-</td></tr>" +
                "<tr><td colspan = '8' align = 'right'> Grand Total: Rs "
                        + Math.Round(Convert.ToDouble(GrandTotal))
                        + "/-</td></tr>" +
                "</table>";

            Sms.SendSMS(contact, "Dear Customer Your Order no " + Orderid + " of Amt Rs " + GrandTotal + "/- has been received it will be delivered to you if the payment has been made(ignore if done).For any query contact +91-11-45793861/+91-11-49045464");



            MailMessage message = new MailMessage("info@astaberry.com", billing.Emailid)
            {
                Subject = "Thank you for placing order",
                Body = textBody,
                IsBodyHtml = true
            };
            SmtpClient smtpclient = new SmtpClient("sg2nlvphout-v01.shr.prod.sin2.secureserver.net")
            {
                UseDefaultCredentials = true,
                EnableSsl = false
            };
            smtpclient.Send(message);
            message = null;
            
        }
    }
}
