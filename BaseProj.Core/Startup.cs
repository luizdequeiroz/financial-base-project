using BaseProj.Core.Entities;
using BaseProj.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProj.Core
{
    public class StartupCore : IDesignTimeDbContextFactory<BaseProjContext>
    {
        private static string _connectionString;

        private static IServiceCollection _services;

        public StartupCore StartupCoreInit(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }

        public StartupCore ConfigureDb(IServiceCollection services)
        {
            _services = services.AddDbContext<BaseProjContext>(options => options.UseSqlServer(_connectionString));
            return this;
        }

        public IServiceCollection Inject<TInterface, TImplementation>() =>
            _services.AddTransient(typeof(TInterface), typeof(TImplementation))
                     .AddTransient<IGenericRepository<User>, GenericRepository<User>>();

        public BaseProjContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseProjContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new BaseProjContext(optionsBuilder.Options);
        }
    }
}
