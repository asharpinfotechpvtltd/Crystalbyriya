﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Astaberry.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace Astaberry.Areas.Admin.Pages.Orders
{
    public class PrintInvoice : PageModel
    {
        private readonly Astaberry.Models.ApplicationDbContext _context;

        public PrintInvoice(Astaberry.Models.ApplicationDbContext context)
        {
            _context = context;
        }
        public double MaximumGst { get; set; }
        public TblOrderId TblOrderId { get; set; }
        public TblBillingDetail TblBilling { get; set; }
        public TblShippingDetail TblShipping { get; set; }
        public List<SpOrderProductDetail> TblOrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(string Orderid, string Email)
        {
            string logedin = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(logedin))
            {
                return RedirectToPage("../Login");

            }
            else
            {

                TblOrderId = await _context.TblOrderIds.FirstOrDefaultAsync(m => m.Orderid == Orderid);
                TblBilling = await _context.TblBillingDetails.SingleOrDefaultAsync(tbl => tbl.ContactNumber == Email);
                TblShipping = await _context.TblShippingDetails.SingleOrDefaultAsync(tbl => tbl.ContactNumber == Email);
                var SearchTextNames = new SqlParameter("@OrderCode", Orderid);
                TblOrderDetail = await _context.SpOrderProductDetail.FromSqlRaw("SpOrderProductDetail @OrderCode", SearchTextNames).ToListAsync();
                var maxgst = TblOrderDetail.Max(x => x.ProductGst);
                MaximumGst = maxgst;
                return Page();
            }
        }
    }
}
