using Contracts.IRepositories.Managers;
using Microsoft.AspNetCore.Identity;
using Repositories.Identities;

namespace Repositories.Managers
{
    internal sealed class IdentityRepositoryManager : IIdentityRepositoryManager
    {
        private readonly Lazy<IIdentEmployeeRepository> _identEmployeeRepository;
        private readonly Lazy<IIdentRoleRepository> _identRoleRepository;

        public IdentityRepositoryManager(IDomainRepositories domainRepositories, 
                                    UserManager<IdentEmployee> userManager,
                                    RoleManager<IdentRole> roleManager)
        {
            _identEmployeeRepository = new Lazy<IIdentEmployeeRepository>(()
                => new IdentEmployeeRepository(domainRepositories, userManager));

            _identRoleRepository = new Lazy<IIdentRoleRepository>(()
                => new IdentRoleRepository(domainRepositories, roleManager));

        }

        public IIdentEmployeeRepository IdentEmployee => _identEmployeeRepository.Value;

        public IIdentRoleRepository IdentRole => _identRoleRepository.Value;
    }
}
