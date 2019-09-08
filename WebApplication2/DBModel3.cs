namespace WebApplication2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel3 : DbContext
    {
        public DBModel3()
            : base("name=DBModel3")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Outgoing> Outgoings { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SupplierDetail> SupplierDetails { get; set; }
        public virtual DbSet<SupplyDetail> SupplyDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ContactNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeePhone)
                .IsFixedLength();

            modelBuilder.Entity<SupplierDetail>()
                .Property(e => e.SupplierPhone)
                .IsFixedLength();
        }
    }
}
