using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordApp.Application.Interfaces.CustomMapper;
using WordApp.Application.Interfaces.Repositories;
using WordApp.Application.Interfaces.UnitOfWorks;
using WordApp.Infrastructure.Context;
using WordApp.Infrastructure.CustomMapper;
using WordApp.Infrastructure.Repositories;
using WordApp.Infrastructure.UnitOfWorks;

namespace WordApp.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<IMapper, Mapper>();

        return services;
    }
}
