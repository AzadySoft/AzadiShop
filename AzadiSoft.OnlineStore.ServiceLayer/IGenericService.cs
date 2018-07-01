using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AzadiSoft.OnlineStore.DataLayer;

namespace AzadiSoft.OnlineStore.ServiceLayer
{
    public interface IGenericService<TEntity> where TEntity : class
    {

        IUnitOfWork UnitOfWork { get; }

        IDbSet<TEntity> DbSet { get; }

        IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> expression = null);

        TEntity GetById(object id);

        TEntity Insert(TEntity entity);

        void Update(TEntity entity);

        void DeleteById(object id);

    }
}