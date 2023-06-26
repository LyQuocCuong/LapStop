using Domains.Entities.Base;
using EFCoreService.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EFCoreService.Context
{
    public sealed class LapStopContext : IdentityDbContext<IdentEmployee, IdentRole, Guid>
    {
        public LapStopContext(DbContextOptions<LapStopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentEmployee>().ToTable("IdentEmployee");
            modelBuilder.Entity<IdentRole>().ToTable("IdentRole");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("IdentEmployeeClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("IdentEmployeeRole");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("IdentEmployeeLogin");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("IdentRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("IdentEmployeeToken");

            modelBuilder.ApplyOrderConfigExt();

            modelBuilder.ApplyAttributeConfigExt();

            modelBuilder.ApplyRelationshipConfigExt();

            modelBuilder.ApplySeedingDataExt();

            modelBuilder.ApplySeedingIdentityDataExt();
        }

        public async Task<int> CustomSaveChangesAsync()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is BaseEntity && 
                                       (e.State == EntityState.Added ||
                                        e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
        public DbSet<EmployeeGallery> EmployeeGalleries { get; set; }
        public DbSet<EmployeeRole>  EmployeeRoles { get; set; }  
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<ExportedInvoice> ExportedInvoices { get; set; }
        public DbSet<ExportedInvoiceDetail> ExportedInvoiceDetail { get;set; }
        public DbSet<ImportedInvoice> ImportedInvoices { get;set; }
        public DbSet<ImportedInvoiceDetail> ImportedInvoiceDetail { get;set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set;}
        public DbSet<SalesOrderStatus> SalesOrderStatus { get; set;}
    }
}
