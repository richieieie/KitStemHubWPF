using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Responses;
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
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public partial class OrderDetail : Window
    {
        public OrderDetail(Order order, List<KitInOrderDetailDTO> kits, int subtotal)
        {
            InitializeComponent();

            // Bind kits to the ItemsControl
            KitsList.ItemsSource = kits;

            // Bind order properties
            OrderIdHeaderText.Text = order.Id.ToString();
            OrderIdDisplayText.Text = order.Id.ToString();
            CreatedAtText.Text = order.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
            ShippingStatusText.Text = order.ShippingStatus;
            ShippingAddressText.Text = order.ShippingAddress;
            PhoneNumberText.Text = order.PhoneNumber;
            TotalPriceText.Text = $"{order.Price:N0} đ";
            NoteText.Text = order.Note;

            // Set subtotal
            SubtotalText.Text = $"{subtotal:N0}";
        }
    }
}
