using KitStemHub.Services.IServices;
using System.Windows;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for KitDashboardManager.xaml
    /// </summary>
    public partial class KitDashboardManager : Window
    {
        private int currentPage = 0;
        private readonly int pageSize = 10;
        private readonly IKitService _kitService;
        private readonly ICategoryService _categoryService;
        public KitDashboardManager(IKitService kitService, ICategoryService categoryService)
        {
            _kitService = kitService;
            _categoryService = categoryService;
            InitializeComponent();
            Loaded += KitDataGrid_Loaded;
            Loaded += CategorySearch_Loaded;
        }

        private void CategorySearch_Loaded(object sender, RoutedEventArgs e)
        {
            categorySearchCb.ItemsSource = _categoryService.GetAll();
        }

        private void KitDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            kitDataGrid.ItemsSource = _kitService.Get(currentPage, pageSize, kitNameSearchTxtBox.Text, 0);
        }
    }
}
