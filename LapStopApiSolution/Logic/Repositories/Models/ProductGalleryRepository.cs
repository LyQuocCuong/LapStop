using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public sealed class ProductGalleryRepository : RepositoryBase<ProductGallery>, IProductGalleryRepository
    {
        public ProductGalleryRepository(LapStopContext context) : base(context)
        {
        }
    }
}
