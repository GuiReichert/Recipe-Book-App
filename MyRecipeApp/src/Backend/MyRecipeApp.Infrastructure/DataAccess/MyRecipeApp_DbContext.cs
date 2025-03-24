using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRecipeApp.Domain.Entities;

namespace MyRecipeApp.Infrastructure.DataAccess
{
    public class MyRecipeApp_DbContext : DbContext
    {
        public MyRecipeApp_DbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeApp_DbContext).Assembly);
        }

    }
}
