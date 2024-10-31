using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.IServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for KitCreateUI.xaml
    /// </summary>
    public partial class KitCreateUI : Window
    {
        private readonly IKitService _kitService;
        private readonly ICategoryService _categoryService;
        public KitCreateUI(IKitService kitService, ICategoryService categoryService)
        {
            _kitService = kitService;
            _categoryService = categoryService;
            InitializeComponent();
            Loaded += KiCategory_Loaded;
        }

        private void KiCategory_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = _categoryService.GetAll();
            kitCategoryCbBox.ItemsSource = categories;
            if (categories != null && categories.Any())
            {
                kitCategoryCbBox.SelectedItem = categories.First();
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void saveKitBtn_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = kitCategoryCbBox.SelectedValue;
            var name = kitNameTxtBox.Text;
            var breif = kitBriefTxtBox.Text;
            var description = kitDescriptionTxtBox.Text;
            var price = kitPriceTxtBox.Text;
            var purchaseCost = kitPurchaseCostTxtBox.Text;
            var status = kitStatusCbBox.SelectedValue.ToString();
            var imageUrl = kitImgBtn.Content;
            if (name == null || name.Length == 0)
            {
                MessageBox.Show("Name is required");
                return;
            }
            if (!int.TryParse(purchaseCost, out int parsedPurchaseCost))
            {
                MessageBox.Show("Please enter correct purchase cost!");
                return;
            }
            if (!int.TryParse(price, out int parsedPrice))
            {
                MessageBox.Show("Please enter correct price!");
                return;
            }
            if (imageUrl == "Choose File")
            {
                MessageBox.Show("Please choose image file!");
                return;
            }

            var kitCreateDTO = new KitCreateDTO
            {
                CategoryId = (int)categoryId,
                Name = name,
                Breif = breif,
                Description = description,
                Price = parsedPrice,
                PurchaseCost = parsedPurchaseCost,
                ImageUrl = kitImgBtn.Content.ToString(),
                Status = status == "Available" ? true : false
            };
            var result = _kitService.Create(kitCreateDTO);
            if (result)
            {
                MessageBox.Show("Kit created successfully");
            }
            else
            {
                MessageBox.Show("Failed to create kit");
            }
        }

        private void kitImgBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (dlg.ShowDialog() == true)
            {
                kitImgBtn.Content = dlg.FileName;
            }
        }
    }
}
