using Contracts.IRepositories;
using System.Linq.Expressions;
using System.Reflection;

namespace Repositories
{
    internal abstract class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : class
    {
        protected readonly LapStopContext _context;
        private readonly DbSet<TModel> _dbSet;

        public RepositoryBase(LapStopContext context)
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

        public void CreateModel(TModel obj)
        {
            _dbSet.Add(obj);
        }

        public void UpdateModel(TModel obj)
        {
            _dbSet.Update(obj);
        }

        public void DeleteModel(TModel obj)
        {
            Type model = typeof(TModel);
            PropertyInfo? prop = model.GetProperty("IsRemoved");
            if (prop != null && prop.PropertyType == typeof(bool))
            {
                prop.SetValue(obj, true);
            }
        }

        public void DeleteModelPermanently(TModel obj)
        {
            _dbSet.Remove(obj);
        }
    }
}
