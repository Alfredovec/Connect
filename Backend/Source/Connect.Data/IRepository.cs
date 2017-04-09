using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Connect.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        T Find(params object[] keyObjects);

        void LoadNavigation(T entity);

        void LoadNavigation(IEnumerable<T> entities);

        void Save();
    }
}
