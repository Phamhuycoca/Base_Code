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
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(long id);
        List<T> Search(string search);

    }
}
