namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Outgoing")]
    public partial class Outgoing
    {
        public int outgoingId { get; set; }

        public double? employeeSalary { get; set; }

        public double? supplierCost { get; set; }

        public double? purchaseFood { get; set; }

        public double? tax { get; set; }

        public double? utilityBills { get; set; }

        public double? transportCost { get; set; }
    }
}
