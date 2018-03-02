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
using System.Globalization;

namespace WebSite.Controllers
{
    public class ForSaleController : Controller
    {
        private TestikEntities db = new TestikEntities();

        // GET: ForRents
   
        public ActionResult Index( int ?price, int? page)

        {

            //Create DropDown list from ForRent Table price column and show it in view
            //var xz = db.ForRent.Select(x => x.price).ToList();
            //SelectList list = new SelectList(xz, "price");
            //ViewBag.pricelist = list;
       
            if (price == null)
            {
                IEnumerable<ForSale> forsales = db.ForSale.ToList().OrderByDescending(y => y.ID);
                return View(forsales.ToList().ToPagedList(page ?? 1, 50));
            }
            IEnumerable<ForSale> forsale = db.ForSale.Where(x => x.price <= price);
                return View(forsale.ToList().ToPagedList(page ?? 1, 50));

            

            }
       

        // GET: ForRents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForSale forsale = db.ForSale.Find(id);
            if (forsale == null)
            {
                return HttpNotFound();
            }
            return View(forsale);
        }

        // GET: ForRents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,phone,price")] ForSale forsale, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            try

            {
                if (image1 == null && image2 == null)
                {
                    db.ForSale.Add(forsale);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ForSale");
                }
                else if (image1 == null && image2 != null)
                {
                    ViewBag.Ms = "Please upload image #1 first";
                    return View();
                }
                else
                if (image1.ContentType.ToLower() != "image/jpg" &&
                   image1.ContentType.ToLower() != "image/jpeg" &&
                    image1.ContentType.ToLower() != "image/pjpeg" &&
                    image1.ContentType.ToLower() != "image/gif" &&
                    image1.ContentType.ToLower() != "image/x-png" &&
                    image1.ContentType.ToLower() != "image/png"

                    )
                {
                    ViewBag.Ms = "Only Image can be uploaded";
                    return View();
                }
                else if (image1 != null && image2 == null)
                {
                    forsale.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(forsale.image, 0, image1.ContentLength);
                    db.ForSale.Add(forsale);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ForSale");
                }
                else
                if (image1.ContentType.ToLower() != "image/jpg" &&
                   image1.ContentType.ToLower() != "image/jpeg" &&
                    image1.ContentType.ToLower() != "image/pjpeg" &&
                    image1.ContentType.ToLower() != "image/gif" &&
                    image1.ContentType.ToLower() != "image/x-png" &&
                    image1.ContentType.ToLower() != "image/png" ||
                    image2.ContentType.ToLower() != "image/jpg" &&
                    image2.ContentType.ToLower() != "image/jpeg" &&
                    image2.ContentType.ToLower() != "image/pjpeg" &&
                    image2.ContentType.ToLower() != "image/gif" &&
                    image2.ContentType.ToLower() != "image/x-png" &&
                    image2.ContentType.ToLower() != "image/png"
                    )
                {
                    ViewBag.Ms = "Only Image can be uploaded";
                    return View();
                }

                else
                if (ModelState.IsValid)
                {


                    forsale.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(forsale.image, 0, image1.ContentLength);

                    forsale.image1 = new byte[image2.ContentLength];
                    image2.InputStream.Read(forsale.image1, 0, image2.ContentLength);

                    db.ForSale.Add(forsale);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ForSale");
                }
            }

            catch
            {
                
                return View();

            }

            return View(forsale);
        }

        // GET: ForRents/Edit/5
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForSale forsale = db.ForSale.Find(id);
            if (forsale == null)
            {
                return HttpNotFound();
            }
            return View(forsale);
        }

        // POST: ForRents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,phone")] ForSale forsale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forsale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forsale);
        }

        // GET: ForRents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForSale forsale = db.ForSale.Find(id);
            if (forsale == null)
            {
                return HttpNotFound();
            }
            return View(forsale);
        }

        // POST: ForRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForSale forsale = db.ForSale.Find(id);
            db.ForSale.Remove(forsale);
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
