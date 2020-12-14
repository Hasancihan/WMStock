using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WMEnvanter.Context;
using WMStock.Models;

namespace WMStock.Controllers
{
    public class ModalsController : Controller
    {
        private ProductManagementContext db = new ProductManagementContext();

        // GET: Modals
        public ActionResult Index()
        {
            var modals = db.Modals.Include(m => m.Brand).Include(m => m.Category);
            return View(modals.ToList());
        }

        // GET: Modals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modal modal = db.Modals.Find(id);
            if (modal == null)
            {
                return HttpNotFound();
            }
            return View(modal);
        }

        // GET: Modals/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Modals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModalID,ModalName,CategoryID,BrandID")] Modal modal)
        {
            if (ModelState.IsValid)
            {
                db.Modals.Add(modal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", modal.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", modal.CategoryID);
            return View(modal);
        }

        // GET: Modals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modal modal = db.Modals.Find(id);
            if (modal == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", modal.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", modal.CategoryID);
            return View(modal);
        }

        // POST: Modals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModalID,ModalName,CategoryID,BrandID")] Modal modal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", modal.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", modal.CategoryID);
            return View(modal);
        }

        // GET: Modals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modal modal = db.Modals.Find(id);
            if (modal == null)
            {
                return HttpNotFound();
            }
            return View(modal);
        }

        // POST: Modals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modal modal = db.Modals.Find(id);
            db.Modals.Remove(modal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult getBrandList(int CategoryID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Brand> BrandList = db.Brands.Where(x => x.CategoryID == CategoryID).ToList();
            return Json(BrandList, JsonRequestBehavior.AllowGet);

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
