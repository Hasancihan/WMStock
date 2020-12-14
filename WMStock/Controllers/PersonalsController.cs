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
    public class PersonalsController : Controller
    {
        private ProductManagementContext db = new ProductManagementContext();

        // GET: Personals
        public ActionResult Index()
        {
            var personals = db.Personals.Include(p => p.Department);
            return View(personals.ToList());
        }

        // GET: Personals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personals/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalId,Name,Surname,Pjob,DepartmentID")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Personals.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", personal.DepartmentID);
            return View(personal);
        }

        // GET: Personals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", personal.DepartmentID);
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalId,Name,Surname,Pjob,DepartmentID")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", personal.DepartmentID);
            return View(personal);
        }

        // GET: Personals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.Personals.Find(id);
            db.Personals.Remove(personal);
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
        public ActionResult Search(string s)
        {
            return View(db.Personals.Where(x => x.Name.Contains(s) || s == null).ToList());
        }
    }
}
