namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Leave")]
    public partial class Leave
    {
        [DisplayName("Leave ID")]
        [Key]
        [Column("[Leave ID]")]
        public int C_Leave_ID_ { get; set; }

        [DisplayName("Employee Name")]
        [Column("[Employee Name]")]
        [StringLength(50)]
        public string C_Employee_Name_ { get; set; }


        [StringLength(50)]
        public string Reason { get; set; }

        [DisplayName("Leave Type")]
        [Column("[Leave Type]")]
        [StringLength(50)]
        public string C_Leave_Type_ { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Column("[Start date]", TypeName = "date")]
        public DateTime? C_Start_date_ { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Column("[End date]", TypeName = "date")]
        public DateTime? C_End_date_ { get; set; }

        public int? Length { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [DisplayName("Document Image Upload")]
        [Column("[Document]")]
        [StringLength(50)]
        public string C_Document_ { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
