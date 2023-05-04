using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IBrandRepository
    {
        List<Brand> GetAll(bool isTrackChanges);

        Brand? GetOneById(bool isTrackChanges, Guid brandId);

        bool IsValidId(Guid id);

        void Create(Brand brand);

        void Delete(Brand brand);
    }
}
