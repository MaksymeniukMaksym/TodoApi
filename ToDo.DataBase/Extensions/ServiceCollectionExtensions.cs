using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataBase.Repository;
using ToDo.DataBase.Repository.Abstraction;

namespace ToDo.DataBase.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IUserDataRepository, UserDataRepository>();

            return services;
        }
    }
}
