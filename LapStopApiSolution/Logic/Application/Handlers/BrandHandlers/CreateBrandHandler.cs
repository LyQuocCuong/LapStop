using Application.Commands.BrandCommands;
using Application.Handlers.Base;
using Contracts.IRepositories;
using Contracts.Utilities;
using Domains.Entities;
using DTO.Input.FromBody.Creation;
using DTO.Output.Data;
using MediatR;

namespace Application.Handlers.BrandHandlers
{
    public sealed class CreateBrandHandler
        : BaseRequestHandler, IRequestHandler<CreateBrandCommand, BrandDto>
    {
        public CreateBrandHandler(IDomainRepositories domainRepositories, UtilityServiceManager utilityServices) 
            : base(domainRepositories, utilityServices)
        {
        }

        public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand newBrand = UtilityServices.Mapper.ExecuteMapping<BrandForCreationDto, Brand>(request.CreationDto);
            EntityRepositories.Brand.Create(newBrand);
            await SaveChanges();
            return UtilityServices.Mapper.ExecuteMapping<Brand, BrandDto>(newBrand);
        }
    }
}
