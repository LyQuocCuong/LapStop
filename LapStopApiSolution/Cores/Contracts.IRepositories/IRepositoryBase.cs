using System.Linq.Expressions;

namespace Contracts.IRepositories
{
    public interface IRepositoryBase<TModel> where TModel : class
    {
        IQueryable<TModel> FindAll(bool isTrackChanges);

        IQueryable<TModel> FindByCondition(bool isTrackChanges, Expression<Func<TModel, bool>> expression);
        
        void Create(TModel obj);
        
        void Update(TModel obj);
        
        void Delete(TModel obj);

        void DeletePermanently(TModel obj);
    }
}
