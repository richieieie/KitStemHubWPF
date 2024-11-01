using KitStemHub.App.Extensions;
using KitStemHub.App.PaymentMethod;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider ServiceProvider { get; set; }
        private IConfiguration Configuration { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            serviceCollection.AddApplicationServices(config);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            //Remember to delete this:
            var mainWindow = ServiceProvider.GetRequiredService<CartUI>();
            mainWindow.Show();


        }
    }

}
