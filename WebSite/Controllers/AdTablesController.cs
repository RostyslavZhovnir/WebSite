using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AdTablesController : Controller
    {
        private TestikEntities db = new TestikEntities();

        // GET: AdTables
        //[Authorize]
        public ActionResult Index()
        {
            return View(db.AdTable.ToList());
        }

        // GET: AdTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdTable adTable = db.AdTable.Find(id);
            if (adTable == null)
            {
                return HttpNotFound();
            }
           
            
            return View(adTable);
        }

        // GET: AdTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,phone")] AdTable adTable,HttpPostedFileBase image1, HttpPostedFileBase image2) //ttpPostedFileBase image was new
        {

            try

            {
                if (image1 == null && image2 == null)
                {
                    db.AdTable.Add(adTable);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
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
                    adTable.image = new byte[image1.ContentLength];
                    image1.InputStream.Read(adTable.image, 0, image1.ContentLength);
                    db.AdTable.Add(adTable);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
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
                   

                adTable.image = new byte[image1.ContentLength];
                image1.InputStream.Read(adTable.image, 0, image1.ContentLength);

                adTable.image1 = new byte[image2.ContentLength];
                image2.InputStream.Read(adTable.image1, 0, image2.ContentLength);

                db.AdTable.Add(adTable);
                db.SaveChanges();
                return RedirectToAction("Index", "AdTables");
            }
            }
            
            catch 
            {
                ViewBag.Ms = "Only Images can be uploaded";
                return View();

    }
          
            return View(adTable);
}

                    
                    

           
        

        // GET: AdTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdTable adTable = db.AdTable.Find(id);
            if (adTable == null)
            {
                return HttpNotFound();
            }
            return View(adTable);
        }

        // POST: AdTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,phone")] AdTable adTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adTable);
        }

        // GET: AdTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdTable adTable = db.AdTable.Find(id);
            if (adTable == null)
            {
                return HttpNotFound();
            }
            return View(adTable);
        }

        // POST: AdTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdTable adTable = db.AdTable.Find(id);
            db.AdTable.Remove(adTable);
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
