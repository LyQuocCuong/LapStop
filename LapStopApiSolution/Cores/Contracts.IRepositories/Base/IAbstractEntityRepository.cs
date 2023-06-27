using System.Linq.Expressions;

namespace Contracts.IRepositories.Base
{
    public interface IAbstractEntityRepository<TEntity> : IAbstractRepository where TEntity : class
    {
        IQueryable<TEntity> FindAll(bool isTrackChanges);

        IQueryable<TEntity> FindByCondition(bool isTrackChanges, Expression<Func<TEntity, bool>> expression);

        void CreateEntity(TEntity obj);

        void UpdateEntity(TEntity obj);

        void DeleteEntity(TEntity obj);

        void DeleteEntityPermanently(TEntity obj);

        Task BulkCreateEntities(IEnumerable<TEntity> entities);

        Task BulkUpdateEntities(IEnumerable<TEntity> entities);
    }
}
