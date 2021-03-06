namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplyDetail
    {
        [Key]
        public int SupplyId { get; set; }

        public string SupplierName { get; set; }

        [Required]
        public string ItemName { get; set; }

        public double UnitPrice { get; set; }

        public int NoOfUnits { get; set; }

        public double TotalPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        //[Column("Date", TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
