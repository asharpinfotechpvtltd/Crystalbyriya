//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Astaberry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public  class TblBanner
    {
        public int Id { get; set; }
        [DisplayName("Mobile Image Name")]
        public string MobileImageName { get; set; }

        [DisplayName("Desktop Image Name")]
        public string DesktopImageName { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Sub Category Name")]
        public string SubCategoryName { get; set; }

        [DisplayName("Alt")]
        public string Alt { get; set; }
    }
}
