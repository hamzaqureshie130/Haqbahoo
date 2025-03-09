using InfrastructionLayer.Haqbahoo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InfrastructionLayer.Haqbahoo
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //for connection string
            var connectionString = configuration.GetConnectionString("DefaultConnect") ??
                throw new InvalidOperationException("Connection string 'DefaultConnect' not found.");

            services.AddDbContext<ApplicationDbContext>(
                                              option => option.UseSqlServer(connectionString,
                                              b =>
                                              {
                                                  b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                                                  b.CommandTimeout(180);
                                              })
                                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Transient);
            //for identity
            //services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //                                                              .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //add Repository

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
          

            return services;
        }
    }
}
