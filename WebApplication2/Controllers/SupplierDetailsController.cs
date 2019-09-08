using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class SupplierDetailsController : Controller
    {
        private DBModel3 db = new DBModel3();

        // GET: SupplierDetails
        public ActionResult Index(string searchBy, string search)
        {
            if (search == "SupplierEmail")
            {
                return View(db.SupplierDetails.Where(x => x.SupplierEmail.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.SupplierDetails.Where(x => x.SupplierName.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: SupplierDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierDetail supplierDetail = db.SupplierDetails.Find(id);
            if (supplierDetail == null)
            {
                return HttpNotFound();
            }
            return View(supplierDetail);
        }

        // GET: SupplierDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,SupplierName,SupplierEmail,SupplierPhone")] SupplierDetail supplierDetail)
        {
            if (ModelState.IsValid)
            {
                db.SupplierDetails.Add(supplierDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierDetail);
        }

        // GET: SupplierDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierDetail supplierDetail = db.SupplierDetails.Find(id);
            if (supplierDetail == null)
            {
                return HttpNotFound();
            }
            return View(supplierDetail);
        }

        // POST: SupplierDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,SupplierName,SupplierEmail,SupplierPhone")] SupplierDetail supplierDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierDetail);
        }

        // GET: SupplierDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierDetail supplierDetail = db.SupplierDetails.Find(id);
            if (supplierDetail == null)
            {
                return HttpNotFound();
            }
            return View(supplierDetail);
        }

        // POST: SupplierDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierDetail supplierDetail = db.SupplierDetails.Find(id);
            db.SupplierDetails.Remove(supplierDetail);
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
