using DTO.Creation;
using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IBrandService
    {
        List<BrandDto> GetAll(bool isTrackChanges);
        BrandDto? GetById(bool isTrackChanges, Guid id);
        BrandDto CreateBrand(BrandForCreationDto creationDto);
    }
}
