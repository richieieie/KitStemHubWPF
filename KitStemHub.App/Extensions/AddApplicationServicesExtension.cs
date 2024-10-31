using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Repositories.Repositories;
using KitStemHub.Services.Helpers;
using KitStemHub.Services.IServices;
using KitStemHub.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KitStemHub.App.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<KitStemHubWpfContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStringDB"))
            );

            // Helpers
            services.AddAutoMapper(typeof(DefaultAutoMapperProfile));

            // Repositories
            services.AddScoped<IKitRepository, KitRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IKitService, KitService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // WPF components
            services.AddTransient<LoginWindow>();
            services.AddTransient<KitCreateUI>();
            services.AddTransient<KitDashboardManager>();
            services.AddTransient<Window1>();

            return services;
        }
    }
}
