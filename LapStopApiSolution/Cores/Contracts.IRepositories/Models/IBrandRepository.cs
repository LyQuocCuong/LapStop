using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IBrandRepository
    {
        List<Brand> GetAll(bool isTrackChanges);
        Brand? GetById(bool isTrackChanges, Guid id);
        void CreateBrand(Brand brand);
    }
}
