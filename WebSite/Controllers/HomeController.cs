using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
       // private TestikEntities db = new TestikEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        
        //Send email method
        [HttpPost]
        public ActionResult Contact(string message, string phone, string email)
        {
                MailMessage EmailText = new MailMessage(email, "rasty.home@gmail.com"); //from to emails
                EmailText.Subject = "New Email from yavusa.com";
                EmailText.Body = "Hello Admin,<br/> you have new message from: "+email+"<br/> Contact phone number: " + phone +"<br/>" + message;
                EmailText.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(EmailText);
                ViewBag.Succes = "The message has been sent";
            return View();
        }
    }
}