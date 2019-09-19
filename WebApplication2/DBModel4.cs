namespace WebApplication2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel4 : DbContext
    {
        public DBModel4()
            : base("name=DBModel4")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeePhone)
                .IsFixedLength();

            modelBuilder.Entity<Leave>()
                .Property(e => e.C_Employee_Name_)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.C_Leave_Type_)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.C_Document_)
                .IsUnicode(false);
        }
    }
}
