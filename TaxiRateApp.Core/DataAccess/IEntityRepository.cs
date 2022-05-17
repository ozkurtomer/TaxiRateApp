using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using TaxiRateApp.Entities.Abstract;

namespace TaxiRateApp.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
