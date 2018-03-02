using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using PagedList;
using PagedList.Mvc;
using WebSite.Helpers;

namespace WebSite.Controllers
{
    public class ServicesController : Controller
    {
        private TestikEntities db = new TestikEntities();

     
        public ActionResult Index(int?page)
        {
            IEnumerable<Services> services = db.Services.ToList().OrderByDescending(y => y.ID);
            return View(services.ToList().ToPagedList(page ?? 1, 20));
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
           
            
            return View(service);
        }

     
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,phone")] Services services,HttpPostedFileBase image1, HttpPostedFileBase image2) //ttpPostedFileBase image was new
        {

            try

            {
                if (image1 == null && image2 == null)
                {
                    db.Services.Add(services);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Services");
                }
                else if (image1 == null && image2 != null)
                {
                    ViewBag.Ms = "Please upload image #1 first";
                    return View();
                }
                else if (CreateHelper.pictureNotImage1(image1))
                {
                    ViewBag.Ms = "Only Image can be uploaded";
                    return View();
                }
                else if (image1 != null && image2 == null)
                {
                    services.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(services.image, 0, image1.ContentLength);
                    db.Services.Add(services);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Services");
                }
                else if (CreateHelper.pictureNotImage(image1, image2))
                {
                    ViewBag.Ms = "Only Image can be uploaded";
                    return View();
                }
            
                else if (ModelState.IsValid)
                {
                services.image = new byte[image1.ContentLength];
                image1.InputStream.Read(services.image, 0, image1.ContentLength);
                services.image1 = new byte[image2.ContentLength];
                image2.InputStream.Read(services.image1, 0, image2.ContentLength);
                db.Services.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index", "Services");
            }
            }
            
            catch 
            {
                ViewBag.Ms = "Only Images can be uploaded";
                return View();

    }
          
            return View(services);
}

                    
                    

           
        

     
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,phone")] Services service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

    
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Services service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
