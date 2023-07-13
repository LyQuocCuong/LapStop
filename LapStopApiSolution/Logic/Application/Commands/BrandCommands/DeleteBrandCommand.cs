using MediatR;

namespace Application.Commands.BrandCommands
{
    public sealed class DeleteBrandCommand
        : IRequest
    {
        public Guid BrandId { get; }

        public DeleteBrandCommand(Guid brandId) 
        {
            BrandId = brandId;
        }
    }
}
