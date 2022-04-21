using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using TaxiRateApp.Entities.Abstract;

namespace TaxiRateApp.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
