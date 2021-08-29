using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTeam.Core.Interfaces;
using MyTeam.Infrastructure.Data;
using MyTeam.Infrastructure.Repositories;



namespace MyTeam.Infrastructure
{
    public static class InfrastructureDependecy
    {
        public static IServiceCollection AddInfraDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("MyTeam.WebApiCore")));

            return services;
        }
    }
}
