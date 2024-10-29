using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Responses;
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
    /// Interaction logic for OrderDashboardStaff.xaml
    /// </summary>
    public partial class OrderDashboardStaff : Window
    {
        private readonly IOrderService _orderService;
        private int _currentPage = 1;
        private const int PageSize = 10;
        private int _totalPages = 1;

        public OrderDashboardStaff(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;

            LoadOrders();
        }

        private void LoadOrders()
        {
            // Get filter parameters
            string search = SearchTextBox.Text;
            string? status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            DateTimeOffset? startDate = StartDatePicker.SelectedDate;
            DateTimeOffset? endDate = EndDatePicker.SelectedDate;

            // Fetch orders with pagination and filters
            var (orders, totalPages) = _orderService.GetOrders(search, status, startDate, endDate, _currentPage, PageSize);

            OrdersDataGrid.ItemsSource = orders;
            _totalPages = totalPages;

            // Update pagination display
            PageInfoTextBlock.Text = $"Page {_currentPage} of {_totalPages}";
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Search by email or name")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        // Event handler for when the TextBox loses focus
        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search by email or name";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1; // Reset to first page on new search
            LoadOrders();
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadOrders();
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadOrders();
            }
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                // Get KitInOrderDetailDTOs using the service
                List<KitInOrderDetailDTO> kitDetails = _orderService.GetKitInOrderDetails(selectedOrder.Id);

                // Calculate the subtotal
                int subtotal = kitDetails.Sum(dto => dto.TotalPrice);

                // Open the details window with KitInOrderDetailDTOs and subtotal
                OrderDetail detailsWindow = new OrderDetail(kitDetails, subtotal);
                detailsWindow.ShowDialog();
            }
        }

        private void ActionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected Order from the DataGrid row
            if (sender is ComboBox comboBox && comboBox.DataContext is Order selectedOrder)
            {
                // Get the newly selected status
                string newStatus = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                if (newStatus != null && newStatus != selectedOrder.ShippingStatus)
                {
                    // Update the status in the Order object
                    selectedOrder.ShippingStatus = newStatus;

                    // Save the updated Order to the database
                    bool updateSuccess = _orderService.updateOrderStatus(selectedOrder);
                    if (updateSuccess)
                    {
                        MessageBox.Show($"Order {selectedOrder.Id} status updated to {newStatus}", "Update Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the order status.", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
