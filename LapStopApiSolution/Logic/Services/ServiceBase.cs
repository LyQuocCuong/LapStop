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

        // Execute a mapping from the source object to a NEW destination object.
        // The source type is INFERRED from the source object.
        public TDestination MappingToNewObj<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        //Execute a mapping from the source object to the EXISTING destination object.
        public object MappingToExistingObj(object fromSource, object toExistingDestination)
        {
            return _mapper.Map(fromSource, toExistingDestination);
        }

    }
}
