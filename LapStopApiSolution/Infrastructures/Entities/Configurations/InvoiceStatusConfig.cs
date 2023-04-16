using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configurations
{
    public class InvoiceStatusConfig : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new InvoiceStatus()
                {
                    Id = new Guid("7187a500-d213-11ed-92cb-1903471dbe5a"),
                    Name = "Admin",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new InvoiceStatus()
                {
                    Id = new Guid("7187a501-d213-11ed-92cb-1903471dbe5a"),
                    Name = "Manager",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new InvoiceStatus()
                {
                    Id = new Guid("7187a502-d213-11ed-92cb-1903471dbe5a"),
                    Name = "Manager",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
