using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices;

namespace Services
{
    internal abstract class ServiceBase : IServiceBase
    {
        protected readonly IRepositoryManager _repositoryManager; 
        private readonly IMapper _mapper;

        internal ServiceBase(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public TDestination MappingTo<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

    }
}
