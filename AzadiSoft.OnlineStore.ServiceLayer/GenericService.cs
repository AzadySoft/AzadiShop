using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AzadiSoft.OnlineStore.DataLayer;

namespace AzadiSoft.OnlineStore.ServiceLayer
{
    public class GenericService<TEntity>: IGenericService<TEntity> where TEntity: class 
    {
        public IUnitOfWork UnitOfWork { get; }

        public IDbSet<TEntity> DbSet { get; }

        public GenericService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DbSet = unitOfWork.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return DbSet.Where(expression);
            }
            else
            {
                return DbSet.AsQueryable();
            }
        }

        public TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public void Update(TEntity entity)
        {
            var entry = UnitOfWork.Entry(entity);

            entry.State = EntityState.Modified;

            UnitOfWork.SaveChanges();
          
        }

        public void DeleteById(object id)
        {
            var entity = GetById(id);

            DbSet.Remove(entity);

            UnitOfWork.SaveChanges();
        }
    }
}