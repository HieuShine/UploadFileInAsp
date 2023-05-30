using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using uploadFile.Models;

namespace uploadFile.Controllers
{
    public class doanhngiepsController : Controller
    {
        private Models.DbContext db = new Models.DbContext();

        // GET: doanhngieps
        public ActionResult Index()
        {
            var doanhngieps = db.doanhngieps.Include(d => d.tailieudinhkem);
            return View(doanhngieps.ToList());
        }

        // GET: doanhngieps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doanhngiep doanhngiep = db.doanhngieps.Find(id);
            if (doanhngiep == null)
            {
                return HttpNotFound();
            }
            return View(doanhngiep);
        }

        // GET: doanhngieps/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.tailieudinhkems, "id", "DuongDan");
            return View();
        }

        // POST: doanhngieps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDN,tenDN,id")] doanhngiep doanhngiep)
        {
            if (ModelState.IsValid)
            {
                db.doanhngieps.Add(doanhngiep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.tailieudinhkems, "id", "DuongDan", doanhngiep.id);
            return View(doanhngiep);
        }

        // GET: doanhngieps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doanhngiep doanhngiep = db.doanhngieps.Find(id);
            if (doanhngiep == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.tailieudinhkems, "id", "DuongDan", doanhngiep.id);
            return View(doanhngiep);
        }

        // POST: doanhngieps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDN,tenDN,id")] doanhngiep doanhngiep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanhngiep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.tailieudinhkems, "id", "DuongDan", doanhngiep.id);
            return View(doanhngiep);
        }

        // GET: doanhngieps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doanhngiep doanhngiep = db.doanhngieps.Find(id);
            if (doanhngiep == null)
            {
                return HttpNotFound();
            }
            return View(doanhngiep);
        }

        // POST: doanhngieps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doanhngiep doanhngiep = db.doanhngieps.Find(id);
            db.doanhngieps.Remove(doanhngiep);
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
