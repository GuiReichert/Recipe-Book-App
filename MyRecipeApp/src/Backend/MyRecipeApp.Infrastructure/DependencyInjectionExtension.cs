using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeApp.Domain.Repositories;
using MyRecipeApp.Domain.Repositories.User;
using MyRecipeApp.Infrastructure.DataAccess;
using MyRecipeApp.Infrastructure.DataAccess.Repositories;

namespace MyRecipeApp.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            var connectionString = "Server = GUILHERME\\SQLEXPRESS; Database=MyRecipeApp; Trusted_Connection=true; TrustServerCertificate=true;";

            services.AddDbContext<MyRecipeApp_DbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
