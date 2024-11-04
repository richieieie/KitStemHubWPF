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
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IKitRepository, KitRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            // Services
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IKitService, KitService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            // WPF components
            services.AddTransient<LoginWindow>();
            services.AddTransient<OrderDashboardStaff>();
            services.AddTransient<PaymentMethodView>();
            
            services.AddTransient<CartUI>();
           
         


            services.AddTransient<KitCreateUI>();
            services.AddTransient<KitUpdateUI>();
            services.AddTransient<KitDashboardManager>();
            services.AddTransient<KitShoppingWindow>();
            services.AddTransient<OrderUI>();
            services.AddTransient<Window1>();
            services.AddTransient<RegisterWindow>();
            
            services.AddTransient<StaffManageDashboard>();

            return services;
        }
    }
}

