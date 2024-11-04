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
    /// Interaction logic for CartUI.xaml
    /// </summary>
    public partial class CartUI : Window
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        public CartUI(ICartService cartService, IOrderService orderService)
        {
            _orderService = orderService;
            _cartService = cartService;
            InitializeComponent();
            Loaded += dgCartList_Loaded;
            Loaded += tbTotal_Loaded;
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);
            var kitId = int.Parse(txtKitId.Text);
            var quantity = int.Parse(txtQuantity.Text);
            var result = _cartService.UpdateByKitId(guid, kitId, quantity);
            if (result)
            {
                MessageBox.Show("Cập nhật số lượng thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật số lượng thất bại!");
            }
            Page_Loaded(sender, e);
        }

        private void btnDeleteByKitId_Click(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);
            var kitId = int.Parse(txtKitId.Text);
            var result = _cartService.RemoveByKitId(guid, kitId);
            if (result)
            {
                MessageBox.Show("Xóa Kit ra khỏi giỏ hàng thành công!");
            }
            else
            {
                MessageBox.Show("Xóa Kit ra khỏi giỏ hàng thất bại!");
            }
            Page_Loaded(sender, e);
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);
            var result = _cartService.RemoveAll(guid);
            if (result)
            {
                MessageBox.Show("Xóa giỏ hàng thành công!");
            }
            else
            {
                MessageBox.Show("Xóa giỏ hàng thất bại!");
            }
            Page_Loaded(sender, e);
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            var frmOrder = new OrderUI(_cartService, _orderService);
            frmOrder.Show();
            this.Close();
        }
    }
}
