using KitStemHub.Repositories.Models;
using KitStemHub.Services.Services;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserService _userService;

        public RegisterWindow(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            //LoadRoles();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RoleId = (int?)RoleComboBox.SelectedValue,
                Status = StatusCheckBox.IsChecked
            };

            if (_userService.RegisterUser(newUser))
            {
                MessageBox.Show("User registered successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Username or email already exists.");
            }
        }
    }
}
