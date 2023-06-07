using AutoMapper;
using Contracts.MappingService;

namespace InfraServices.AutoMapper
{
    public class AutoMapperService : IMappingService
    {
        private readonly IMapper _autoMapper;

        public AutoMapperService(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _autoMapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _autoMapper.Map(source, destination);
        }
    }
}
