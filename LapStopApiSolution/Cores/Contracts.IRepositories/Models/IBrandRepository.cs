using Domains.Models;
using DTO.Parameters;

namespace Contracts.IRepositories.Models
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync(bool isTrackChanges, BrandParameters parameters);

        Task<Brand?> GetOneByIdAsync(bool isTrackChanges, Guid brandId);

        Task<bool> IsValidIdAsync(Guid id);

        void Create(Brand brand);

        void Delete(Brand brand);
    }
}
