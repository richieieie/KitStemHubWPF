using KitStemHub.Repositories.Models;
using KitStemHub.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {


        private readonly KitStemHubWpfContext _context;
        private readonly IUserService _service;
        private IServiceProvider _serviceProvider;

        public LoginWindow(IUserService service, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = new KitStemHubWpfContext();
            _service = service;
            _serviceProvider = serviceProvider;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        private void LoginUser()
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;


            var roleId = _service.Login(email, password);
            if (roleId == 1)
            {
                var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                this.Close();
                mainWindow.Show();
            }
            else
            {
                string errorMessage = roleId switch
                {
                    2 => "Access Denied. Sellers are not allowed to access.",
                    3 => "Access Denied. Customers are not allowed to access.",
                    _ => "Access Denied. Your role does not have any access."
                };

                MessageBox.Show(errorMessage, "Login Restricted", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
