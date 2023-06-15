using Common.Variables;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    internal sealed class EmployeeRoleConfig : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            // Seeding Data
            builder.HasData(
                new EmployeeRole()
                {
                    Id = CommonVariables.Seeding.EmployeeRole_Admin_Id,
                    Name = CommonVariables.Seeding.EmployeeRole_Admin_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new EmployeeRole()
                {
                    Id = CommonVariables.Seeding.EmployeeRole_Manager_Id,
                    Name = CommonVariables.Seeding.EmployeeRole_Manager_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new EmployeeRole()
                {
                    Id = CommonVariables.Seeding.EmployeeRole_Staff_Id,
                    Name = CommonVariables.Seeding.EmployeeRole_Staff_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                }
            );
        }
    }
}
