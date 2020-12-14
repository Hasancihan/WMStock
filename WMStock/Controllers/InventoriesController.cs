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
    public class InventoriesController : Controller
    {
        private ProductManagementContext db = new ProductManagementContext();

        // GET: Inventories
        public ActionResult Index()
        {
            var inventories = db.Inventories.Include(i => i.Brand).Include(i => i.Category).Include(i => i.Location).Include(i => i.Modal).Include(i => i.Personal);
            return View(inventories.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName");
            ViewBag.ModalID = new SelectList(db.Modals, "ModalID", "ModalName");
            ViewBag.PersonalID = new SelectList(db.Personals, "PersonalId", "Name");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryID,InventoryName,PersonalID,LocationID,CategoryID,BrandID,ModalID,DateTime")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", inventory.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", inventory.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", inventory.LocationID);
            ViewBag.ModalID = new SelectList(db.Modals, "ModalID", "ModalName", inventory.ModalID);
            ViewBag.PersonalID = new SelectList(db.Personals, "PersonalId", "Name", inventory.PersonalID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", inventory.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", inventory.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", inventory.LocationID);
            ViewBag.ModalID = new SelectList(db.Modals, "ModalID", "ModalName", inventory.ModalID);
            ViewBag.PersonalID = new SelectList(db.Personals, "PersonalId", "Name", inventory.PersonalID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryID,InventoryName,PersonalID,LocationID,CategoryID,BrandID,ModalID,DateTime")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", inventory.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", inventory.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", inventory.LocationID);
            ViewBag.ModalID = new SelectList(db.Modals, "ModalID", "ModalName", inventory.ModalID);
            ViewBag.PersonalID = new SelectList(db.Personals, "PersonalId", "Name", inventory.PersonalID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult getBrandList(int CategoryID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Brand> BrandList = db.Brands.Where(x => x.CategoryID == CategoryID).ToList();
            return Json(BrandList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getModalList(int BrandID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Modal> ModalList = db.Modals.Where(x => x.BrandID == BrandID).ToList();
            return Json(ModalList, JsonRequestBehavior.AllowGet);
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
