using Contracts.IRepositories.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace Repositories.Base
{
    internal abstract class AbstractRepository<TModel> : IAbstractRepository<TModel> where TModel : class
    {
        protected readonly LapStopContext _context;
        private readonly DbSet<TModel> _dbSet;

        public AbstractRepository(LapStopContext context)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
        }

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
    }
}
