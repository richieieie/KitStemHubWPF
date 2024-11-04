using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.IServices;
using System.Windows;
using System.Windows.Controls;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for KitShoppingWindow.xaml
    /// </summary>
    public partial class KitShoppingWindow : Window
    {
        private int currentPage = 0;
        private readonly int pageSize = 10;
        private int totalPages = 0;
        private readonly IServiceProvider _serviceProvider;
        private readonly IKitService _kitService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        public KitShoppingWindow(IServiceProvider serviceProvider, IKitService kitService, ICategoryService categoryService, ICartService cartService)
        {
            _serviceProvider = serviceProvider;
            _kitService = kitService;
            _categoryService = categoryService;
            _cartService = cartService;
            //Application.Current.Resources["user"] = new User()
            //{ 
            //    Id = Guid.Parse("FECAA6D2-8AB8-408E-A5F0-009BD38C05D7")
            //};
            InitializeComponent();
            Loaded += KitDataGrid_Loaded;
            //Loaded += CategorySearch_Loaded;
        }

        //private void CategorySearch_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var categories = _categoryService.GetAll().ToList();
        //    categories.Insert(0, new Category { Id = 0, Name = "All" });
        //    categorySearchCb.ItemsSource = categories;
        //}

        private void KitDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var (kits, totalPages) = _kitService.Get(currentPage, pageSize, "", 0);
            kitDataGrid.ItemsSource = kits;
            this.totalPages = totalPages;
        }

        private void addToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)Application.Current.Resources["user"];
            if (user == null)
            {
                MessageBox.Show("You are not logged in!", "Failed to add to cart", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Button button = (Button)sender;
            var cartDTO = new CartCreateDTO()
            {
                UserId = user.Id,
                KitId = (int) button.Tag,
                Quantity = 1 
            };
            var result = _cartService.CreateCart(cartDTO);
            if (result)
            {
                MessageBox.Show("Added to cart successfully");
            }
            else
            {
                MessageBox.Show("You are not logged in!", "Failed to add to cart", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void previousBtn_Click(object sender, RoutedEventArgs e)
        {
            currentPage = currentPage > 0 ? currentPage - 1 : currentPage;
            var (kits, _) = _kitService.Get(currentPage, pageSize, "", 0);
            kitDataGrid.ItemsSource = kits;
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            currentPage = currentPage < totalPages ? currentPage + 1 : currentPage;
            var (kits, _) = _kitService.Get(currentPage, pageSize, "", 0);
            kitDataGrid.ItemsSource = kits;
        }
    }
}
