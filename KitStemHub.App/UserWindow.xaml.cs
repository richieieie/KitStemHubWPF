using KitStemHub.Repositories.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly KitStemHubWpfContext _context;
        public UserWindow()
        {
            InitializeComponent();
            _context = new KitStemHubWpfContext();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _context.Users.Include(u => u.Role).ToList();
            UsersDataGrid.ItemsSource = users;
        }

        private void BanUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                selectedUser.Status = false; // Assume false means banned
                _context.SaveChanges();
                MessageBox.Show($"{selectedUser.Username} has been banned.");
                LoadUsers(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Please select a user to ban.");
            }
        }
    }
}
