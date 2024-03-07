using Base_code.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Infrastructure.Context
{
    public class Base_Context : DbContext
    {
        public Base_Context(DbContextOptions<Base_Context> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<User> Users { get; set; }

    }
}
