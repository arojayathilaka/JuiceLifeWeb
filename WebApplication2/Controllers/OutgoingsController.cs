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
    public class OutgoingsController : Controller
    {
        private DBModel3 db = new DBModel3();

        // GET: Outgoings
        public ActionResult Index()
        {
            return View(db.Outgoings.ToList());
        }

        // GET: Outgoings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outgoing outgoing = db.Outgoings.Find(id);
            if (outgoing == null)
            {
                return HttpNotFound();
            }
            return View(outgoing);
        }

        // GET: Outgoings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Outgoings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "outgoingId,employeeSalary,supplierCost,purchaseFood,tax,utilityBills,transportCost")] Outgoing outgoing)
        {
            if (ModelState.IsValid)
            {
                db.Outgoings.Add(outgoing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(outgoing);
        }

        // GET: Outgoings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outgoing outgoing = db.Outgoings.Find(id);
            if (outgoing == null)
            {
                return HttpNotFound();
            }
            return View(outgoing);
        }

        // POST: Outgoings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "outgoingId,employeeSalary,supplierCost,purchaseFood,tax,utilityBills,transportCost")] Outgoing outgoing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outgoing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outgoing);
        }

        // GET: Outgoings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outgoing outgoing = db.Outgoings.Find(id);
            if (outgoing == null)
            {
                return HttpNotFound();
            }
            return View(outgoing);
        }

        // POST: Outgoings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outgoing outgoing = db.Outgoings.Find(id);
            db.Outgoings.Remove(outgoing);
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
