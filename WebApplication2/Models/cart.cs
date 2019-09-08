using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class cart
    {
        public int productid { get; set; }
        public String productname { get; set; }
        public float price { get; set; }
        public int qty { get; set; }
        public float bill { get; set; }
    }
}