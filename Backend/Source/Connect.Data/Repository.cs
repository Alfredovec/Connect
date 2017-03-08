using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Connect.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
       private readonly ConnectDbContext _context;

        public Repository(ConnectDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T Find(params object[] keyObjects)
        {
            return _context.Set<T>().Find(keyObjects);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
