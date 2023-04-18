using Contracts.IRepositories;

namespace Services
{
    internal abstract class ServiceBase
    {
        protected IRepositoryManager _repositoryManager; 
        internal ServiceBase(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
