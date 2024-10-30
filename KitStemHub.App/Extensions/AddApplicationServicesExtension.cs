using KitStemHub.App.PaymentMethod;
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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

            // Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            

            // WPF components
            services.AddTransient<LoginWindow>();
            services.AddTransient<OrderDashboardStaff>();
            services.AddTransient<PaymentMethodView>();

           
         


            return services;
        }
    }
}
