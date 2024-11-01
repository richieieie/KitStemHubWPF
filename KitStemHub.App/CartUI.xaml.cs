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
        public CartUI(ICartService cartService)
        {
            _cartService = cartService;
            InitializeComponent();
        }

        private void dgCartList_Loaded(object sender, RoutedEventArgs e)
        {
            string guidString = "e2133c4e-7685-4542-a9da-0cccb20a5383";
            Guid guid = Guid.Parse(guidString);
            var cartList = _cartService.GetCart(guid);
            dgCartList.ItemsSource = cartList;
        }
    }
}
