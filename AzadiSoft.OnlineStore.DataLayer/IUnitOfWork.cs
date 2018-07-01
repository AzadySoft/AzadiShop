using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AzadiSoft.OnlineStore.DataLayer
{
    public interface IUnitOfWork
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}