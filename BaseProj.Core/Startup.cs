using BaseProj.Core.Entities;
using BaseProj.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProj.Core
{
    public class StartupCore : IDesignTimeDbContextFactory<BaseProjContext>
    {
        public static string connectionString { get; set; }

        public BaseProjContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseProjContext>();
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseNpgsql(connectionString);

            return new BaseProjContext(optionsBuilder.Options);
        }
    }

    public static class StartupExtension
    {
        public static IServiceCollection ConfigureConnection(this IServiceCollection services, string connectionString)
        {
            StartupCore.connectionString = connectionString;
            return services;
        }

        public static IServiceCollection Inject<TInterface, TImplementation>(this IServiceCollection services) => 
            services.AddDbContext<BaseProjContext>(options => options.UseNpgsql(StartupCore.connectionString))
                    .AddTransient(typeof(TInterface), typeof(TImplementation))
                    .AddTransient<IGenericRepository<User>, GenericRepository<User>>()
                    .AddTransient<IGenericRepository<Client>, GenericRepository<Client>>();
    }
}
