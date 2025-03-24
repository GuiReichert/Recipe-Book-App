using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeApp.Apllication.Services.Automapper;
using MyRecipeApp.Apllication.Services.Criptography;
using MyRecipeApp.Apllication.UseCases.User.Register;

namespace MyRecipeApp.Apllication
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncripter(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var mapper = new AutoMapper.MapperConfiguration(options => options.AddProfile(new MapperProfile())).CreateMapper();

            services.AddScoped(options => mapper);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }


        private static void AddPasswordEncripter(IServiceCollection services)
        {
            services.AddScoped(options => new PasswordEncripter());
        }


    }
}
