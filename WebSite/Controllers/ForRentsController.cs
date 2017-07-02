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

namespace WebSite.Controllers
{
    public class ForRentsController : Controller
    {
        private TestikEntities db = new TestikEntities();

        // GET: ForRents
   
        public ActionResult Index( int ?price, int? page)

        {
            if (price == null)
            {
                IEnumerable<ForRent> forrents = db.ForRent.ToList().OrderByDescending(y => y.ID);
                return View(forrents.ToList().ToPagedList(page ?? 1, 50));
            }
            IEnumerable<ForRent> forrent = db.ForRent.Where(x => x.price <= price);
                return View(forrent.ToList().ToPagedList(page ?? 1, 50));
            }
        

        // GET: ForRents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForRent forRent = db.ForRent.Find(id);
            if (forRent == null)
            {
                return HttpNotFound();
            }
            return View(forRent);
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
        public ActionResult Create([Bind(Include = "ID,Description,phone,price")] ForRent forRent, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            try

            {
                if (image1 == null && image2 == null)
                {
                    db.ForRent.Add(forRent);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ForRents");
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
                    forRent.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(forRent.image, 0, image1.ContentLength);
                    db.ForRent.Add(forRent);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ForRents");
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


                    forRent.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(forRent.image, 0, image1.ContentLength);

                    forRent.image1 = new byte[image2.ContentLength];
                    image2.InputStream.Read(forRent.image1, 0, image2.ContentLength);

                    db.ForRent.Add(forRent);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ForRents");
                }
            }

            catch
            {
                
                return View();

            }

            return View(forRent);
        }

        // GET: ForRents/Edit/5
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForRent forRent = db.ForRent.Find(id);
            if (forRent == null)
            {
                return HttpNotFound();
            }
            return View(forRent);
        }

        // POST: ForRents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,phone")] ForRent forRent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forRent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forRent);
        }

        // GET: ForRents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForRent forRent = db.ForRent.Find(id);
            if (forRent == null)
            {
                return HttpNotFound();
            }
            return View(forRent);
        }

        // POST: ForRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForRent forRent = db.ForRent.Find(id);
            db.ForRent.Remove(forRent);
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
