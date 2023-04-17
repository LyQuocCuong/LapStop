using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
    public interface IRepositoryBase<TModel> where TModel : class
    {
        IQueryable<TModel> FindAll(bool isTrackChanges);

        IQueryable<TModel> FindByCondition(bool isTrackChanges, Expression<Func<TModel, bool>> expression);
        
        void Create(TModel obj);
        
        void Update(TModel obj);
        
        void Delete(TModel obj);
    }
}
