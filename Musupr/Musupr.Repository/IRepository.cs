using System;

namespace Musupr.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        System.Collections.Generic.IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<System.Linq.IQueryable<TEntity>, System.Linq.IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? top = null);
        System.Linq.IQueryable<TEntity> queryGet(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<System.Linq.IQueryable<TEntity>, System.Linq.IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? top = null);
        TEntity GetByID(object id);
        System.Linq.IQueryable<TEntity> GetSet(string includeProperties = "");
        System.Collections.Generic.IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        TEntity Insert(TEntity entity);
        void ExecuteSqlCommand(string query, params object[] parameters);
        void Update(TEntity entityToUpdate);
        int Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null);
    }
}
