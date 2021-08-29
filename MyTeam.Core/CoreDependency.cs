using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTeam.Core.Interfaces;
using MyTeam.Core.Services.User;


namespace MyTeam.Core
{
    public static class CoreDependency
    {
        public static IServiceCollection AddCoreDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
