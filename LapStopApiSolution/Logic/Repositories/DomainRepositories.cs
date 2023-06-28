using Contracts.IRepositories.Managers;
using Microsoft.AspNetCore.Identity;
using Repositories.Managers;

namespace Repositories
{
    public sealed class DomainRepositories : IDomainRepositories
    {
        private readonly LapStopContext _context;
        private readonly Lazy<IEntityRepositoryManager> _entityRepositories;
        private readonly Lazy<IIdentityRepositoryManager> _identityRepositories;


        public DomainRepositories(LapStopContext context,
                                 UserManager<IdentEmployee> userManager,
                                 RoleManager<IdentRole> roleManager)
        {
            _context = context;

            _entityRepositories = new Lazy<IEntityRepositoryManager>(() 
                    => new EntityRepositoryManager(new EntityRepositoryParams(context, this)));

            _identityRepositories = new Lazy<IIdentityRepositoryManager>(() 
                    => new IdentityRepositoryManager(this, userManager, roleManager));
        }

        public async Task SaveChangesToDatabaseAsync()
        {
            await _context.CustomSaveChangesAsync();
        }

        public IEntityRepositoryManager EntityRepositories => _entityRepositories.Value;

        public IIdentityRepositoryManager IdentityRepositories => _identityRepositories.Value;
    }
}
