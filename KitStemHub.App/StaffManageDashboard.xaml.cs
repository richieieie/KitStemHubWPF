using KitStemHub.Repositories.Models;
using KitStemHub.Services.IServices;
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
    /// Interaction logic for StaffManageDashboard.xaml
    /// </summary>
    public partial class StaffManageDashboard : Window
    {
        private readonly IUserService _userService;
        private int _currentPage = 0;
        private const int PageSize = 10;
        private List<User> _currentUsers;

        public StaffManageDashboard(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            LoadUsers();
        }

        private void LoadUsers()
        {
            int staffRoleId = 2; 
            _currentUsers = _userService.GetUsersByRole(staffRoleId, _currentPage * PageSize, PageSize);
            UserDataGrid.ItemsSource = _currentUsers;
            txtPageInfo.Text = $"Page {_currentPage + 1}";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            int staffRoleId = 2; 
            if (!string.IsNullOrEmpty(searchText))
            {
                
                _currentUsers = _userService.SearchUsersByRoleAndNameOrEmail(staffRoleId, searchText, _currentPage * PageSize, PageSize);
                UserDataGrid.ItemsSource = _currentUsers;
            }
            else
            {
                LoadUsers();
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required for inserting a new user.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = txtUsername.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Password = password,
                RoleId = 2, // Assign the role as 'Staff'; adjust if needed
                Status = true // Default to active status
            };

            try
            {
                bool success = _userService.CreateUser(newUser);
                if (success)
                {
                    MessageBox.Show("User inserted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsers(); // Only call LoadUsers() if insertion was successful
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Failed to insert user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("UNIQUE constraint failed"))
                {
                    MessageBox.Show("A user with this username or email already exists. Please use a different username or email.", "Duplicate Entry", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show($"An error occurred while inserting the user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem is User selectedUser)
            {
                try
                {
                    // Retrieve the original entity from the database
                    var userToUpdate = _userService.GetById(selectedUser.Id);

                    if (userToUpdate == null)
                    {
                        MessageBox.Show("User not found for updating.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Store the original values in a temporary object
                    var originalUser = new User
                    {
                        Id = userToUpdate.Id,
                        Username = userToUpdate.Username,
                        FirstName = userToUpdate.FirstName,
                        LastName = userToUpdate.LastName,
                        Email = userToUpdate.Email,
                        PhoneNumber = userToUpdate.PhoneNumber,
                        Address = userToUpdate.Address,
                        RoleId = userToUpdate.RoleId,
                        Status = userToUpdate.Status
                    };

                    // Update the userToUpdate object with new values from the UI
                    userToUpdate.Username = txtUsername.Text.Trim();
                    userToUpdate.FirstName = txtFirstName.Text.Trim();
                    userToUpdate.LastName = txtLastName.Text.Trim();
                    userToUpdate.Email = txtEmail.Text.Trim();
                    userToUpdate.PhoneNumber = txtPhoneNumber.Text.Trim();
                    userToUpdate.Address = txtAddress.Text.Trim();

                    bool success = _userService.UpdateUser(userToUpdate);
                    if (success)
                    {
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadUsers();
                        ResetFields();
                    }
                    else
                    {
                        // No need to modify the grid or collection here, as the data was not changed
                        MessageBox.Show("Failed to update user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Do not update the grid or collection on exception
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("UNIQUE constraint failed"))
                    {
                        MessageBox.Show("A user with this username or email already exists. Please use a different username or email.", "Duplicate Entry", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"An error occurred while updating the user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (UserDataGrid.SelectedItem is User selectedUser)
        //    {
        //        var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            bool success = _userService.DeleteUser(selectedUser.Id);
        //            if (success)
        //            {
        //                MessageBox.Show("User deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //                LoadUsers();
        //                ResetFields();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to delete user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //        }
        //    }
        //}

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            LoadUsers();
            ResetFields();
        }

        private void ResetFields()
        {
            txtUsername.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is User selectedUser)
            {
                bool success = _userService.UpdateUserStatus(selectedUser);
                if (success)
                {
                    MessageBox.Show("User status updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Failed to update user status.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                LoadUsers();
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            LoadUsers();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Disable the update button when there is input in the password field
            btnUpdate.IsEnabled = string.IsNullOrEmpty(txtPassword.Password);
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserDataGrid.SelectedItem is User selectedUser)
            {
                txtUsername.Text = selectedUser.Username;
                txtFirstName.Text = selectedUser.FirstName;
                txtLastName.Text = selectedUser.LastName;
                txtEmail.Text = selectedUser.Email;
                txtPhoneNumber.Text = selectedUser.PhoneNumber;
                txtAddress.Text = selectedUser.Address;

                // Clear the password field and enable the update button
                txtPassword.Clear();
                btnUpdate.IsEnabled = true;
            }
        }
    }
}

