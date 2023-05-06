using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAll();

        BrandDto? GetOneById(Guid brandId);

        BrandForUpdateDto GetDtoForPatch(Guid brandId);

        BrandDto Create(BrandForCreationDto creationDto);

        bool IsValidId(Guid brandId);

        void Update(Guid brandId, BrandForUpdateDto updateDto);

        void Delete(Guid brandId);
    }
}
