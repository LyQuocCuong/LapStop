using Contracts.IRepositories.Base;
using Contracts.IRepositories.Managers;
using Repositories.Parameters;
using System.Linq.Expressions;
using System.Reflection;

namespace Repositories.Base
{
    internal abstract class AbstractEntityRepository<TModel> : 
                                IAbstractEntityRepository<TModel> where TModel : class
    {
        private readonly DbSet<TModel> _dbSet;
        private readonly EntityRepositoryParams _repoParams;

        public AbstractEntityRepository(EntityRepositoryParams repoParams)
        {
            _repoParams = repoParams;
            _dbSet = repoParams.Context.Set<TModel>();
        }


        #region Due to need to call Each Other (Repo call other Repos)
        
        public IEntityRepositoryManager EntityRepositories => _repoParams.DomainRepositories.EntityRepositories;
        
        public IIdentityRepositoryManager IdentityRepositories => _repoParams.DomainRepositories.IdentityRepositories;
        
        #endregion

        public IQueryable<TModel> FindAll(bool isTrackChanges)
        {
            if (isTrackChanges)
            {
                return _dbSet;
            }
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TModel> FindByCondition(bool isTrackChanges, Expression<Func<TModel, bool>> expression)
        {
            if (isTrackChanges)
            {
                return _dbSet.Where(expression);
            }
            return _dbSet.Where(expression).AsNoTracking();
        }

        public void CreateEntity(TModel obj)
        {
            _dbSet.Add(obj);
        }

        public void UpdateEntity(TModel obj)
        {
            _dbSet.Update(obj);
        }

        public void DeleteEntity(TModel obj)
        {
            Type model = typeof(TModel);
            PropertyInfo? prop = model.GetProperty("IsRemoved");
            if (prop != null && prop.PropertyType == typeof(bool))
            {
                prop.SetValue(obj, true);
            }
        }

        public void DeleteEntityPermanently(TModel obj)
        {
            _dbSet.Remove(obj);
        }

        public async Task BulkUpdateEntities(IEnumerable<TModel> entities)
        {
            await _repoParams.Context.BulkUpdateAsync(entities);
        }

        public async Task BulkCreateEntities(IEnumerable<TModel> entities)
        {
            await _repoParams.Context.BulkInsertAsync(entities, options =>
            {
                options.InsertIfNotExists = true;
            });
        }
    }
}
