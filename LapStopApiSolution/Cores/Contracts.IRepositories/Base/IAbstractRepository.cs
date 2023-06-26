using System.Linq.Expressions;

namespace Contracts.IRepositories.Base
{
    public interface IAbstractRepository<TModel> where TModel : class
    {
        IQueryable<TModel> FindAll(bool isTrackChanges);

        IQueryable<TModel> FindByCondition(bool isTrackChanges, Expression<Func<TModel, bool>> expression);

        void CreateEntity(TModel obj);

        void UpdateEntity(TModel obj);

        void DeleteEntity(TModel obj);

        void DeleteEntityPermanently(TModel obj);
    }
}
