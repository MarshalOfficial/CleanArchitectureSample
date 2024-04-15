using CleanArchitectureSample.Application.Contracts.Persistence;
using CleanArchitectureSample.Persistence.Contexts;
using CleanArchitectureSample.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace CleanArchitectureSample.Persistence.Configurations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitectureDbContext>(options =>
                //options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                options.UseInMemoryDatabase("LibrarianDb")
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMemberRepository, MemberRepository>();
            return services;
        }
    }
}