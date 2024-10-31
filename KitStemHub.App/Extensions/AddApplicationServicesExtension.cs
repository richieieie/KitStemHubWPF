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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();

            // WPF components
            services.AddTransient<LoginWindow>();
            services.AddTransient<OrderDashboardStaff>();
            services.AddTransient<CategoryWindow>();
            services.AddTransient<UserWindow>();

            return services;
        }
    }
}

