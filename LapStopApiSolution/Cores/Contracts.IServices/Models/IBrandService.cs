using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface IBrandService
    {
        List<BrandDto> GetAll(bool isTrackChanges);

        BrandDto? GetOneById(bool isTrackChanges, Guid brandId);

        BrandDto Create(BrandForCreationDto creationDto);

        bool IsValidId(Guid brandId);

        void Update(Guid brandId, BrandForUpdateDto updateDto);

        void Delete(Guid brandId);
    }
}
