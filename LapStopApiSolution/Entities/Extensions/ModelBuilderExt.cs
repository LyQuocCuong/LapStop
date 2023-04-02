using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Extensions
{
    public static class ModelBuilderExt
    {
        public static void ConfigAttributeExt(this ModelBuilder modelBuilder)
        {
            #region CUSTOMER ACCOUNT

            modelBuilder.Entity<CustomerAccount>().ToTable("CustomerAccount");
            modelBuilder.Entity<CustomerAccount>()
                .HasKey(ca => ca.CustomerId)
                .HasName("CustomerId");
            modelBuilder.Entity<CustomerAccount>()
                .Property(ca => ca.Username)
                .HasColumnName("Username")
                .IsRequired(true); // NOT nullable

            #endregion

            #region EMPLOYEE ACCOUNT

            modelBuilder.Entity<EmployeeAccount>().ToTable("EmployeeAccount");
            modelBuilder.Entity<EmployeeAccount>()
                .HasKey(ea => ea.EmployeeId)
                .HasName("EmployeeId");
            modelBuilder.Entity<EmployeeAccount>()
                .Property(ea => ea.Username)
                .HasColumnName("Username")
                .IsRequired(true); // NOT nullable

            #endregion

            #region PRODUCT BRAND

            modelBuilder.Entity<ProductBrand>().ToTable("ProductBrand");
            modelBuilder.Entity<ProductBrand>()
                .HasKey(pb => new { pb.ProductId, pb.BrandId });
            modelBuilder.Entity<ProductBrand>()
                .Property(pb => pb.ProductId)
                .HasColumnName("ProductId")
                .IsRequired(true); // NOT nullable
            modelBuilder.Entity<ProductBrand>()
                .Property(pb => pb.BrandId)
                .HasColumnName("BrandId")
                .IsRequired(true); // NOT nullable

            #endregion

        }

        /// <summary>
        /// One-To-Many: START from the class CONTAINING ICollection<>
        /// One-To-One: START from the class does NOT contain FK_ID
        /// </summary>
        public static void ConfigRelationshipExt(this ModelBuilder modelBuilder)
        {
            #region BRAND

            // (1) Brand --> (N) ProductBrand
            modelBuilder.Entity<Brand>()
                .HasMany<ProductBrand>(b => b.ProductsOfABrand)
                .WithOne(pb => pb.Brand)
                .HasForeignKey(pb => pb.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region CART

            // (1) Cart --> (N) CartItem 
            modelBuilder.Entity<Cart>()
                .HasMany<CartItem>(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region CUSTOMER

            // (1) Customer <--> (1) Cart
            modelBuilder.Entity<Customer>()
                .HasOne<Cart>(cus => cus.Cart)
                .WithOne(c => c.Customer)
                .HasForeignKey<Cart>(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Customer <--> (1) CustomerAccount
            modelBuilder.Entity<Customer>()
                .HasOne<CustomerAccount>(c => c.CustomerAccount)
                .WithOne(ca => ca.Customer)
                .HasForeignKey<CustomerAccount>(ca => ca.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Customer --> (N) SalesOrder
            modelBuilder.Entity<Customer>()
                .HasMany<SalesOrder>(cus => cus.SalesOrders)
                .WithOne(so => so.Customer)
                .HasForeignKey(so => so.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EMPLOYEE

            // (1) Employee <--> (1) EmployeeAccount
            modelBuilder.Entity<Employee>()
                .HasOne<EmployeeAccount>(e => e.EmployeeAccount)
                .WithOne(ea => ea.Employee)
                .HasForeignKey<EmployeeAccount>(ea => ea.EmployeeId);

            // (1) Employee --> (N) EmployeeGallery
            modelBuilder.Entity<Employee>()
                .HasMany<EmployeeGallery>(e => e.EmployeeGalleries)
                .WithOne(eg => eg.Employee)
                .HasForeignKey(eg => eg.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Employee --> (N) ImportedInvoice
            modelBuilder.Entity<Employee>()
                .HasMany<ImportedInvoice>(e => e.ImportedInvoices)
                .WithOne(ii => ii.Employee)
                .HasForeignKey(ii => ii.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Employee --> (N) ExportedInvoice
            modelBuilder.Entity<Employee>()
                .HasMany<ExportedInvoice>(e => e.ExportedInvoices)
                .WithOne(ei => ei.Employee)
                .HasForeignKey(ei => ei.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EMPLOYEE ROLE

            // (1) EmployeeRole --> (N) Employee
            modelBuilder.Entity<EmployeeRole>()
                .HasMany<Employee>(er => er.Employees)
                .WithOne(e => e.EmployeeRole)
                .HasForeignKey(e => e.EmployeeRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EMPLOYEE STATUS

            // (1) EmployeeStatus --> (N) Employee
            modelBuilder.Entity<EmployeeStatus>()
                .HasMany<Employee>(es => es.Employees)
                .WithOne(e => e.EmployeeStatus)
                .HasForeignKey(e => e.EmployeeStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EXPORTED INVOICES

            // (1) ExportedInvoice --> (N) ExportedInvoiceDetail
            modelBuilder.Entity<ExportedInvoice>()
                .HasMany<ExportedInvoiceDetail>(ei => ei.ExportedInvoiceDetails)
                .WithOne(eid => eid.ExportedInvoice)
                .HasForeignKey(eid => eid.ExportedInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region IMPORTED INVOICES

            // (1) ImportedInvoice --> (N) ImportedInvoiceDetail
            modelBuilder.Entity<ImportedInvoice>()
                .HasMany<ImportedInvoiceDetail>(ip => ip.ImportedInvoiceDetails)
                .WithOne(iid => iid.ImportedInvoice)
                .HasForeignKey(iid => iid.ImportedInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region INVOICE STATUS

            // (1) InvoiceStatus --> (N) ImportedInvoice
            modelBuilder.Entity<InvoiceStatus>()
                .HasMany<ImportedInvoice>(ins => ins.ImportedInvoices)
                .WithOne(ii => ii.InvoiceStatus)
                .HasForeignKey(ii => ii.InvoiceStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) InvoiceStatus --> (N) ExportedInvoice
            modelBuilder.Entity<InvoiceStatus>()
                .HasMany<ExportedInvoice>(ins => ins.ExportedInvoices)
                .WithOne(ei => ei.InvoiceStatus)
                .HasForeignKey(ei => ei.InvoiceStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region PRODUCT

            // (1) Product --> (N) ProductBrand
            modelBuilder.Entity<Product>()
                .HasMany<ProductBrand>(p => p.BrandsOfAProduct)
                .WithOne(boap => boap.Product)
                .HasForeignKey(boap => boap.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) ProductGallery
            modelBuilder.Entity<Product>()
                .HasMany<ProductGallery>(p => p.ProductGalleries)
                .WithOne(pg => pg.Product)
                .HasForeignKey(pg => pg.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) CartItem
            modelBuilder.Entity<Product>()
                .HasMany<CartItem>(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) SalesOrderDetail
            modelBuilder.Entity<Product>()
                .HasMany<SalesOrderDetail>(p => p.SalesOrderDetails)
                .WithOne(sod => sod.Product)
                .HasForeignKey(sod => sod.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) ExportedInvoiceDetail
            modelBuilder.Entity<Product>()
                .HasMany<ExportedInvoiceDetail>(p => p.ExportedInvoiceDetails)
                .WithOne(eid => eid.Product)
                .HasForeignKey(eid => eid.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) ImportedInvoiceDetail
            modelBuilder.Entity<Product>()
                .HasMany<ImportedInvoiceDetail>(p => p.ImportedInvoiceDetails)
                .WithOne(iid => iid.Product)
                .HasForeignKey(iid => iid.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region PRODUCT STATUS

            // (1) ProductStatus --> (N) Product
            modelBuilder.Entity<ProductStatus>()
                .HasMany<Product>(ps => ps.Products)
                .WithOne(p => p.ProductStatus)
                .HasForeignKey(p => p.ProductStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region SALES ORDER

            // (1) SalesOrder <--> (1) ExportedInvoice
            modelBuilder.Entity<SalesOrder>()
                .HasOne<ExportedInvoice>(so => so.ExportedInvoice)
                .WithOne(ei => ei.SalesOrder)
                .HasForeignKey<ExportedInvoice>(ei => ei.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) SalesOrder --> (N) SalesOrderDetail
            modelBuilder.Entity<SalesOrder>()
                .HasMany<SalesOrderDetail>(so => so.SalesOrderDetails)
                .WithOne(sod => sod.SalesOrder)
                .HasForeignKey(sod => sod.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region SALES ORDER STATUS

            // (1) SalesOrderStatus --> (N) SalesOrder
            modelBuilder.Entity<SalesOrderStatus>()
                .HasMany<SalesOrder>(sos => sos.SalesOrders)
                .WithOne(so => so.SalesOrderStatus)
                .HasForeignKey(so => so.SalesOrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

        }
    }
}
