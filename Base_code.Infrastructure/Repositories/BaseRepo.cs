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
        public readonly Base_Context _context;
        public DbSet<T> _dbSet { get; set; }

        public BaseRepo(Base_Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual T? Get(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

        }
        public virtual void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

        }

        public virtual void Create(List<T> listEntity)
        {
            _dbSet.AddRange(listEntity);
            _context.SaveChanges();
        }
        public virtual void Delete(string id)
        {
            T entity = _dbSet.Find(id) ?? new T();
            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(List<string> listEntity)
        {
            foreach (var item in listEntity)
            {
                Delete(item);
            }
        }

        public virtual void Delete(List<T> listEntity)
        {
            foreach (var item in listEntity)
            {
                Delete(item);
            }
        }


    }
}
