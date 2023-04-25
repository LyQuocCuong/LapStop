using Domains.Models;
using Entities.Configurations;
using Entities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public sealed class LapStopContext : DbContext
    {
        public LapStopContext(DbContextOptions<LapStopContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAttributeConfigExt();

            modelBuilder.ApplyRelationshipConfigExt();

            //modelBuilder.ApplySeedingDataExt();

            base.OnModelCreating(modelBuilder);
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
