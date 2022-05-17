using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaxiRateApp.Entities.Abstract;

namespace TaxiRateApp.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Add(entity).Entity;
                context.SaveChanges();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Remove(entity).Entity;
                context.SaveChanges();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Update(entity).Entity;
                context.SaveChanges();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
