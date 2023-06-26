using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreService.Configurations.Identities
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
