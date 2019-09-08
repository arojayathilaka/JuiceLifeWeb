namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public int ItemCode { get; set; }

        [StringLength(50)]
        public string ItemName { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Condition { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpireDate { get; set; }

        public double? UnitPrice { get; set; }

        [StringLength(20)]
        public string SupplierName { get; set; }
    }
}
