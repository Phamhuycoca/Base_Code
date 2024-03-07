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
       
        private IEnumerable<object> GetKeyValues(T entity)
        {
            var keyProperties = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
            foreach (var property in keyProperties)
            {
                yield return property.PropertyInfo.GetValue(entity);
            }
        }
       

        public List<T> Search(string search)
        {
            return _dbSet.Where(x => x.ToString().Contains(search)).ToList();
        }

        public void Create(T entity)
        {
            try
            {
                if (!_dbSet.Any(e => e == entity))
                {
                    _dbSet.Add(entity);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Create method: {ex.Message}");
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                var entry = _context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    var existingEntity = _dbSet.Find(GetKeyValues(entity).ToArray());
                    if (existingEntity != null)
                    {
                        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                throw; 
            }
        }

        public void Delete(long id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                throw; 
            }
        }
    }
}
