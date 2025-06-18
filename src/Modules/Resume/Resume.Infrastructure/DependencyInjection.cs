using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Infrastructure.Persistence;

namespace Resume.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureResume(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ResumeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}