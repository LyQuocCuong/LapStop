using Application.Handlers.Base;
using Application.Queries.BrandQueries;
using Contracts.IRepositories;
using Contracts.Utilities;
using Domains.Entities;
using DTO.Output.Data;
using MediatR;

namespace Application.Handlers.BrandHandlers
{
    public sealed class GetBrandByIdHandler
        : BaseRequestHandler, IRequestHandler<GetBrandByIdQuery, BrandDto>
    {
        public GetBrandByIdHandler(IDomainRepositories domainRepositories,
                                  UtilityServiceManager utilityServiceManager)
            : base(domainRepositories, utilityServiceManager)
        {
        }

        public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            Brand? brand = await EntityRepositories.Brand.GetOneByIdAsync(request.IsTracking, request.BrandId);
            if (brand != null)
            {
                return UtilityServices.Mapper.ExecuteMapping<Brand, BrandDto>(brand);
            }
            return new BrandDto();
        }
    }
}
