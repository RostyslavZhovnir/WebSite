using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User U)
        {
            TestikEntities OE = new TestikEntities();
            var count = OE.User.Where(x => x.Name == U.Name && x.pass == U.pass).Count();
            if (count == 0)
            {
                ViewBag.Msg = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.Name, false);
                return RedirectToAction("Index", "AdTables");
            }
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}