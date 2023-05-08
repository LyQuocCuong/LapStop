using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;

namespace Contracts.IServices.Models
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllAsync(BrandParameters parameters);

        Task<BrandDto?> GetOneByIdAsync(Guid brandId);

        Task<BrandForUpdateDto> GetDtoForPatchAsync(Guid brandId);

        Task<BrandDto> CreateAsync(BrandForCreationDto creationDto);

        Task<bool> IsValidIdAsync(Guid brandId);

        Task UpdateAsync(Guid brandId, BrandForUpdateDto updateDto);

        Task DeleteAsync(Guid brandId);
    }
}
