using First.App.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace First.App.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
