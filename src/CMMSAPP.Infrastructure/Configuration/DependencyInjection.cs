namespace CMMSAPP.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
           options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        AddRepositories(services);
        return services;
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
    }
}
