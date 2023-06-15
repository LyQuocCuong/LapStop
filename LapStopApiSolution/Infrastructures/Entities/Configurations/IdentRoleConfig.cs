using Common.Variables;
using Domains.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    internal sealed class IdentRoleConfig : IEntityTypeConfiguration<IdentRole>
    {
        public void Configure(EntityTypeBuilder<IdentRole> builder)
        {
            builder.HasData(
                new IdentRole()
                {
                    Id = CommonVariables.Seeding.IdentityRole_Admin_Id,
                    Name = CommonVariables.Seeding.IdentityRole_Admin_Name,
                    NormalizedName = CommonVariables.Seeding.IdentityRole_Admin_Name.ToUpper()
                },
                new IdentRole()
                {
                    Id = CommonVariables.Seeding.IdentityRole_Manager_Id,
                    Name = CommonVariables.Seeding.IdentityRole_Manager_Name,
                    NormalizedName = CommonVariables.Seeding.IdentityRole_Manager_Name.ToUpper()
                }
            );
        }
    }
}
