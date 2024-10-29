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
        public OrderDetail(List<KitInOrderDetailDTO> kits, int subtotal)
        {
            InitializeComponent();

            // Bind kits to the ItemsControl
            KitsList.ItemsSource = kits;

            // Set subtotal
            SubtotalText.Text = $"{subtotal:N0} đ";
        }
    }
}
