using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public void LoadNavigation(T entity)
        {
            foreach (var navigationProperty in GetNavigationProperties(entity))
            {
                var isEnumerable = typeof(IEnumerable).IsAssignableFrom(navigationProperty.PropertyType);
                if (isEnumerable)
                    _context.Entry(entity).Collection(navigationProperty.Name).Load();
                else
                    _context.Entry(entity).Reference(navigationProperty.Name).Load();
            }
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        private IEnumerable<PropertyInfo> GetNavigationProperties(T entity)
        {
            var entityType = entity.GetType();
            var entitySetElementType = ((IObjectContextAdapter)_context).ObjectContext.CreateObjectSet<T>().EntitySet.ElementType;

            return entitySetElementType.NavigationProperties.Select(navigationProperty => entityType.GetProperty(navigationProperty.Name));
        }
    }
}
