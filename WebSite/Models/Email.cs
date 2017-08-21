using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Text Message  is required")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Description must be from 2 to 1000 symbols")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Phone number is not full ")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Check Email Adress ")]
        public string email{ get; set; }
    }
}