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

    public partial class AdTable
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Description must be from 2 to 1000 symbols")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"\d{10,13}", ErrorMessage = "Phone should contains numbers only and be at least 10 numbers lenght ")]
        public string phone { get; set; }
        [DisplayName("Select image #1")]
        public byte[] image { get; set; }
        [DisplayName("Select image #2")]
        public byte[] image1 { get; set; }
        public byte[] image2 { get; set; }
    }
}
