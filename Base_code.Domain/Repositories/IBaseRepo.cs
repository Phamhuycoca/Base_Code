using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Domain.Repositories
{
    public interface IBaseRepo<T> where T : class
    {
        List<T> ListData();
        T GetById(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(long id);
        List<T> Search(string search);

    }
}
