using Contracts.IRepositories.Managers;
using Microsoft.AspNetCore.Identity;
using Repositories.Identities;

namespace Repositories.Managers
{
    internal sealed class IdentityRepositoryManager : IIdentityRepositoryManager
    {
        private readonly Lazy<IIdentEmployeeRepository> _identEmployeeRepository;

        public IdentityRepositoryManager(UserManager<IdentEmployee> userManager,
                                    RoleManager<IdentRole> roleManager)
        {
            _identEmployeeRepository = new Lazy<IIdentEmployeeRepository>(() => new IdentEmployeeRepository(userManager, roleManager));

        }

        public IIdentEmployeeRepository IdentEmployee => _identEmployeeRepository.Value;
    }
}
