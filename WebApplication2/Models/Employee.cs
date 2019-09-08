namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(20)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        public string EmployeeAddress { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [StringLength(20)]
        public string EmployeePosition { get; set; }

        [Required(ErrorMessage = "PhoneNo is required")]
        
        [StringLength(10)]
        public string EmployeePhone { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage ="Invalid Email address")]
        [StringLength(30)]
        public string EmployeeEmail { get; set; }
    }
}
