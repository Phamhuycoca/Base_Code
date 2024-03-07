using Base_code.Domain.Entities;
using Base_code.Domain.Repositories;
using Base_code.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Infrastructure.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(Base_Context context) : base(context)
        {
        }
    }
}
