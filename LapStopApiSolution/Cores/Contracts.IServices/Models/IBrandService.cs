using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface IBrandService
    {
        List<BrandDto> GetAll(bool isTrackChanges);

        BrandDto? GetById(bool isTrackChanges, Guid id);

        BrandDto CreateBrand(BrandForCreationDto creationDto);

        void UpdateBrand(Guid id, BrandForUpdateDto updateDto);

        void DeleteBrand(Guid id);
    }
}
