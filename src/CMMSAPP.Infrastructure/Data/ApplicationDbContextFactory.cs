using Microsoft.EntityFrameworkCore.Design;

namespace CMMSAPP.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
{
    public ApplicationDBContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection")); // یا UseSqlServer

        // توجه: اینجا از کانستراکتور ساده استفاده می‌کنیم، چون mediator در دسترس نیست
        return new ApplicationDBContext(optionsBuilder.Options);
    }
}
