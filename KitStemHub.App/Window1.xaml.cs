using KitStemHub.Repositories.Models;
using KitStemHub.Services.IServices;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private IOrderService _orderService;
        public Window1(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
            LoadOrders();
        }

        private void LoadOrders()
        {
            IEnumerable<Order> orders = _orderService.GetOrdersTest();
            OrdersDataGrid.ItemsSource = orders;
        }
    }
}
