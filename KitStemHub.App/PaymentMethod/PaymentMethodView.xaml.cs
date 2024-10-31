using KitStemHub.Repositories.Models;
using KitStemHub.Services.IServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KitStemHub.App.PaymentMethod
{
    /// <summary>
    /// Interaction logic for PaymentMethodView.xaml
    /// </summary>
    public partial class PaymentMethodView : Window
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private Method _selectedPaymentMethod;

        public PaymentMethodView(IPaymentMethodService paymentMethodService)
        {
            InitializeComponent();
            _paymentMethodService = paymentMethodService;
            LoadData();
        }

        private void LoadData()
        {
            // Load all payment methods from the service and bind them to the DataGrid
            PaymentMethodsDataGrid.ItemsSource = _paymentMethodService.GetPaymentMethods();
        }

        private void PaymentMethodsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected payment method from the DataGrid
            _selectedPaymentMethod = (Method)PaymentMethodsDataGrid.SelectedItem;
            if (_selectedPaymentMethod != null)
            {
                // Populate the input fields with the selected item's details
                NameTextBox.Text = _selectedPaymentMethod.Name;
                NormalizedNameTextBox.Text = _selectedPaymentMethod.NormalizedName;
            }
        }

        private void AddPaymentMethodButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Method object based on the input fields
            var newMethod = new Method
            {
                Name = NameTextBox.Text,
                NormalizedName = NormalizedNameTextBox.Text,
                Status = true // Default status to enabled
            };

            // Insert the new payment method and reload the DataGrid
            _paymentMethodService.InsertPaymentMethod(newMethod);
            LoadData();
            ClearFields();
        }

        private void UpdatePaymentMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPaymentMethod != null)
            {
                // Update the selected payment method with values from the input fields
                _selectedPaymentMethod.Name = NameTextBox.Text;
                _selectedPaymentMethod.NormalizedName = NormalizedNameTextBox.Text;

                // Call the service to update the payment method and reload the DataGrid
                _paymentMethodService.UpdatePaymentMethod(_selectedPaymentMethod);
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a payment method to update.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ToggleStatusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var method = button?.Tag as Method;

            if (method != null)
            {
                // Toggle the status
                method.Status = !(method.Status ?? true);

                // Update the method in the service and reload data to reflect the change
                _paymentMethodService.UpdatePaymentMethod(method);
                LoadData();
            }
        }

        private void ClearFields()
        {
            // Clear the input fields and reset the selected payment method
            NameTextBox.Text = string.Empty;
            NormalizedNameTextBox.Text = string.Empty;
            _selectedPaymentMethod = null;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Name == "NameTextBox" && textBox.Text == "Payment Method Name")
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = Brushes.Black;
                }
                else if (textBox.Name == "NormalizedNameTextBox" && textBox.Text == "Normalized Name")
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = Brushes.Black;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Name == "NameTextBox" && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Payment Method Name";
                    textBox.Foreground = Brushes.Gray;
                }
                else if (textBox.Name == "NormalizedNameTextBox" && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Normalized Name";
                    textBox.Foreground = Brushes.Gray;
                }
            }
        }
    }
}
