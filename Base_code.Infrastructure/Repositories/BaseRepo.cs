using Base_code.Domain.Repositories;
using Base_code.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Infrastructure.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, new()
    {
        private readonly Base_Context _context;
        DbSet<T> _dbSet;
        public BaseRepo(Base_Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public List<T> ListData()
        {
            return _dbSet.ToList();
        }
        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }
        public bool Create(T entity)
        {
            if (!_dbSet.Any(e => e == entity))
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var existingEntity = _dbSet.Find(GetKeyValues(entity).ToArray());
                if (existingEntity == null)
                {
                    return false;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return true;
        }
        private IEnumerable<object> GetKeyValues(T entity)
        {
            var keyProperties = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
            foreach (var property in keyProperties)
            {
                yield return property.PropertyInfo.GetValue(entity);
            }
        }
        public bool Delete(long id)
        {
            var category = _dbSet.Find(id);
            if (category == null)
            {
                return false;
            }
            _dbSet.Remove(category);
            _context.SaveChanges();
            return true;
        }

        public List<T> Search(string search)
        {
            return _dbSet.Where(x => x.ToString().Contains(search)).ToList();
        }
    }
}
