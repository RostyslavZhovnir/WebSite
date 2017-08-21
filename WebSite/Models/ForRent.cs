//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ForRent
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Description must be from 2 to 1000 symbols")]
        public string Description { get; set; }

        
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Phone number is not full ")]
        public string phone { get; set; }

        [DisplayName("Select image #1")]
        public byte[] image { get; set; }

        [DisplayName("Select image #2")]
        public byte[] image1 { get; set; }

        [RegularExpression(@"\d{1,10}", ErrorMessage = "Price should contains numbers only")]
        public Nullable<decimal> price { get; set; }
    }
}
