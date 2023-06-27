using Microsoft.AspNetCore.Identity;

namespace Repositories.Identities
{
    internal sealed class IdentRoleRepository : IIdentRoleRepository
    {
        private readonly RoleManager<IdentRole> _roleManager;

        public IdentRoleRepository(IDomainRepositories domainRepositories,
                                    RoleManager<IdentRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<bool> IsRoleExistsAsync(string roleName)
        {
            return _roleManager.RoleExistsAsync(roleName);
        }
    }
}
