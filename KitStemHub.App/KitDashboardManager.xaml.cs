using KitStemHub.Repositories.Models;
using KitStemHub.Services.IServices;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for KitDashboardManager.xaml
    /// </summary>
    public partial class KitDashboardManager : Window
    {
        private int currentPage = 0;
        private readonly int pageSize = 10;
        private int totalPages = 0;
        private readonly IServiceProvider _serviceProvider;
        private readonly IKitService _kitService;
        private readonly ICategoryService _categoryService;
        public KitDashboardManager(IServiceProvider serviceProvider, IKitService kitService, ICategoryService categoryService)
        {
            _serviceProvider = serviceProvider;
            _kitService = kitService;
            _categoryService = categoryService;
            InitializeComponent();
            Loaded += KitDataGrid_Loaded;
            Loaded += CategorySearch_Loaded;
        }

        private void CategorySearch_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = _categoryService.GetAll().ToList();
            categories.Insert(0, new Category { Id = 0, Name = "All" });
            categorySearchCb.ItemsSource = categories;
        }

        private void KitDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var (kits, totalPages) = _kitService.Get(currentPage, pageSize, "", 0);
            kitDataGrid.ItemsSource = kits;
            this.totalPages = totalPages;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = (int) categorySearchCb.SelectedValue;
            var kitName = kitNameSearchTxtBox.Text;
            var (kits, totalPages) = _kitService.Get(currentPage, pageSize, kitName, categoryId);
            kitDataGrid.ItemsSource = kits;
            this.totalPages = totalPages;
        }

        private void previousBtn_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = (int)categorySearchCb.SelectedValue;
            var kitName = kitNameSearchTxtBox.Text;
            currentPage = currentPage > 0 ? currentPage - 1 : currentPage;
            var (kits, _) = _kitService.Get(currentPage, pageSize, kitName, 0);
            kitDataGrid.ItemsSource = kits;
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = (int)categorySearchCb.SelectedValue;
            var kitName = kitNameSearchTxtBox.Text;
            currentPage = currentPage < totalPages ? currentPage + 1 : currentPage;
            var (kits, _) = _kitService.Get(currentPage, pageSize, kitName, 0);
            kitDataGrid.ItemsSource = kits;
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            var createKitWindow = _serviceProvider.GetRequiredService<KitCreateUI>();
            createKitWindow.Show();
        }

        private void deleteOrRestoreBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var kitId = (int)button.Tag;
            var isSuccess = _kitService.DeleteOrRestoreById(kitId);
            if (!isSuccess)
            {
                MessageBox.Show("Cập nhật trạng thái của Kit thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái của Kit Thất bại!");
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
        }
    }
}
