using Contracts.IRepositories;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal abstract class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : class
    {
        protected LapStopContext _context;
        protected DbSet<TModel> _dbSet;

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

        public void Create(TModel obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(TModel obj)
        {
            _dbSet.Update(obj);
        }

        public void Delete(TModel obj)
        {
            //_dbSet.Remove(obj);
        }
    }
}
