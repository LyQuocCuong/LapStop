using System.Linq.Expressions;

namespace Contracts.IRepositories
{
    public interface IRepositoryBase<TModel> where TModel : class
    {
        IQueryable<TModel> FindAll(bool isTrackChanges);

        IQueryable<TModel> FindByCondition(bool isTrackChanges, Expression<Func<TModel, bool>> expression);
        
        void CreateModel(TModel obj);
        
        void UpdateModel(TModel obj);
        
        void DeleteModel(TModel obj);

        void DeleteModelPermanently(TModel obj);
    }
}
