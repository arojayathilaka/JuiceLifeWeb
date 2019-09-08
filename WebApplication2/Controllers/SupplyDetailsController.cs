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
    public class SupplyDetailsController : Controller
    {
        private DBModel3 db = new DBModel3();

        // GET: SupplyDetails
        public ActionResult Index(string searchBy, string search)
        {
            if (search == "SuppllierName")
            {
                return View(db.SupplyDetails.Where(x => x.SupplierName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.SupplyDetails.Where(x => x.ItemName.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: SupplyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyDetail supplyDetail = db.SupplyDetails.Find(id);
            if (supplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(supplyDetail);
        }

        // GET: SupplyDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplyId,SupplierName,ItemName,UnitPrice,NoOfUnits,TotalPrice,Date")] SupplyDetail supplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.SupplyDetails.Add(supplyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplyDetail);
        }

        // GET: SupplyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyDetail supplyDetail = db.SupplyDetails.Find(id);
            if (supplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(supplyDetail);
        }

        // POST: SupplyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplyId,SupplierName,ItemName,UnitPrice,NoOfUnits,TotalPrice,Date")] SupplyDetail supplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplyDetail);
        }

        // GET: SupplyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyDetail supplyDetail = db.SupplyDetails.Find(id);
            if (supplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(supplyDetail);
        }

        // POST: SupplyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplyDetail supplyDetail = db.SupplyDetails.Find(id);
            db.SupplyDetails.Remove(supplyDetail);
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
