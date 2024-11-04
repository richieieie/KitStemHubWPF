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
    /// Interaction logic for OrderUI.xaml
    /// </summary>
    public partial class OrderUI : Window
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        public OrderUI(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
            InitializeComponent();
            Loaded += dgCartList_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgCartList_Loaded(sender, e);
            tbTotal_Loaded(sender, e);
        }

        private void dgCartList_Loaded(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);
            var cartList = _cartService.GetCart(guid);
            dgCartList.ItemsSource = cartList;
        }

        private void tbTotal_Loaded(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);
            var total = _cartService.GetTotal(guid);
            tbTotal.Text = total.ToString();
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);

            var address = txtAddress.Text;
            var phoneNumeber = txtPhoneNumber.Text;
            var note = txtNote.Text;
            
            var result = _orderService.CreateOrder(guid, address, phoneNumeber, note);

            if (result)
            {
                MessageBox.Show("Đặt hàng thành công!");
            }
            else
            {
                MessageBox.Show("Đặt hàng thất bại!");
            }
            Page_Loaded(sender, e);
        }
    }
}
