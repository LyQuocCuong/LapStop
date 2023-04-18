using AutoMapper;
using Contracts.IRepositories;

namespace Services
{
    internal abstract class ServiceBase
    {
        protected IRepositoryManager _repositoryManager; 
        protected IMapper _mapper;

        internal ServiceBase(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
    }
}
