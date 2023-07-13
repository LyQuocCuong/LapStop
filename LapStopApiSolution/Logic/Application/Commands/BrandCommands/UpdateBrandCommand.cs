using DTO.Input.FromBody.Update;
using MediatR;

namespace Application.Commands.BrandCommands
{
    public sealed class UpdateBrandCommand
        : IRequest
    {
        public Guid BrandId { get; }
        public BrandForUpdateDto UpdateDto { get; }

        public UpdateBrandCommand(Guid brandId, 
                                  BrandForUpdateDto updateDto) 
        {
            BrandId = brandId;
            UpdateDto = updateDto;
        }
    }
}
