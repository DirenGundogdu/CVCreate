using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;
using Users.Domain.Abstractions;
using Users.Infrastructure.Persistence;
using Users.Infrastructure.Repositories;

namespace Users.Infrastructure;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUser(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }