using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ToDo.DataBase.Model;
using ToDo.DataBase.Repository;
using ToDo.DataBase.Repository.Abstraction;
using Microsoft.AspNetCore.Identity;

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
