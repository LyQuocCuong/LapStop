﻿using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(LapStopContext context) : base(context)
        {
        }

        public void Create(Brand brand)
        {
            base.CreateModel(brand);
        }

        public void Delete(Brand brand)
        {
            base.DeleteModel(brand);
        }

        public List<Brand> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public Brand? GetOneById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, brand => brand.Id == id).FirstOrDefault();
        }
    }
}
