using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        MyConnectionEntities db = new MyConnectionEntities();
        public ActionResult Index()
        {
            Session["usr_id"] = 1;
            if (TempData["cart"] != null)
            {
                float t = 0;
                List<cart> li2 = TempData["cart"] as List<cart>;
                foreach (var item in li2)
                {
                    t += item.bill;
                }
                TempData["tot"] = t;
            }
            TempData.Keep();
            return View(db.Products.OrderByDescending(x => x.pro_id).ToList());
        }
        public ActionResult Addtocart(int? Id)
        {
            Product p = db.Products.Where(x => x.pro_id == Id).SingleOrDefault();
            return View(p);
        }

        List<cart> li = new List<cart>();
        [HttpPost]

        public ActionResult Addtocart(Product pi, string qty, int Id)
        {
            Product p = db.Products.Where(x => x.pro_id == Id).SingleOrDefault();
            cart c = new cart();
            c.productid = p.pro_id;
            c.productname = p.pro_name;
            c.price = (float)p.pro_price;
            c.qty = Convert.ToInt32(qty);
            c.bill = c.price * c.qty;
            if (TempData["cart"] == null)
            {
                li.Add(c);
                TempData["cart"] = li;
            }
            else
            {
                List<cart> li2 = TempData["cart"] as List<cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.productid == c.productid)
                    {
                        item.qty += c.qty;
                        item.bill += c.bill;
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    li2.Add(c);
                }
            }



            TempData.Keep();

            return RedirectToAction("Index");
        }

        public ActionResult remove(int? id)
        {
            List<cart> li2 = TempData["cart"] as List<cart>;
            cart c = li2.Where(x => x.productid == id).SingleOrDefault();
            li2.Remove(c);
            float h = 0;
            foreach (var item in li2)
            {
                h += item.bill;
            }
            TempData["tot"] = h;
            return RedirectToAction("checkout");
        }


        public ActionResult checkout()
        {
            TempData.Keep();

            return View();
        }


        [HttpPost]

        public ActionResult checkout(Order o)
        {
            List<cart> li = TempData["cart"] as List<cart>;
            Invoice iv = new Invoice();
            iv.in_fk_users = Convert.ToInt32(Session["usr_id"].ToString());
            iv.in_date = System.DateTime.Now;
            iv.in_totalbill = (float)TempData["tot"];
            db.Invoices.Add(iv);
            db.SaveChanges();

            foreach (var item in li)
            {
                Order od = new Order();
                od.ord_fk_product = item.productid;
                od.ord_fk_invoice = iv.in_id;
                od.ord_date = System.DateTime.Now;
                od.ord_qty = item.qty;
                od.ord_unitprice = (int)item.price;
                od.ord_bill = item.bill;
                db.Orders.Add(od);
                db.SaveChanges();
            }

            TempData.Remove("tot");
            TempData.Remove("cart");

            TempData["msg"] = "Transaction Compteted........";
            TempData.Keep();
            return RedirectToAction("Index");

        }

        public ActionResult delivery()
        {
            return View();
        }
    }
}