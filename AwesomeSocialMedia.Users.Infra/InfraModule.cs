using AwesomeSocialMedia.Users.Core.Repositories;
using AwesomeSocialMedia.Users.Infra.Persistence;
using AwesomeSocialMedia.Users.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSocialMedia.Users.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services
                .AddDb(connectionString)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UsersDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}