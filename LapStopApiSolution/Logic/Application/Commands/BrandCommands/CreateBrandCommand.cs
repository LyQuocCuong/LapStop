using DTO.Input.FromBody.Creation;
using DTO.Output.Data;
using MediatR;

namespace Application.Commands.BrandCommands
{
    public sealed class CreateBrandCommand
        : IRequest<BrandDto>
    {
        public CreateBrandCommand(BrandForCreationDto creationDto) 
        {
            CreationDto = creationDto;
        }

        public BrandForCreationDto CreationDto { get; }

    }
}
