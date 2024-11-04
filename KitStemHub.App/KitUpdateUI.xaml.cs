using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.IServices;
using System.Windows;

namespace KitStemHub.App
{
    /// <summary>
    /// Interaction logic for KitUpdateUI.xaml
    /// </summary>
    public partial class KitUpdateUI : Window
    {
        public int KitId { get; set; }
        public Action<object, RoutedEventArgs>? KitLoaded { get; internal set; }
        private readonly IKitService _kitService;
        private readonly ICategoryService _categoryService;
        public KitUpdateUI(IKitService kitService, ICategoryService categoryService)
        {
            _kitService = kitService;
            _categoryService = categoryService;
            InitializeComponent();
            Loaded += KitCategory_Loaded;
            Loaded += KitDetails_Loaded;
        }

        private void KitDetails_Loaded(object sender, RoutedEventArgs e)
        {
            var kitDTO = _kitService.GetById(KitId);
            kitCategoryCbBox.SelectedValue = kitDTO.CategoryId;
            kitNameTxtBox.Text = kitDTO.Name;
            kitBriefTxtBox.Text = kitDTO.Breif;
            kitDescriptionTxtBox.Text = kitDTO.Description;
            kitPriceTxtBox.Text = kitDTO.Price.ToString();
            kitPurchaseCostTxtBox.Text = kitDTO.PurchaseCost.ToString();
            kitImgBtn.Content = kitDTO.ImageUrl;
        }

        private void KitCategory_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = _categoryService.GetAll();
            kitCategoryCbBox.ItemsSource = categories;
            if (categories != null && categories.Any())
            {
                kitCategoryCbBox.SelectedItem = categories.First();
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

        private void saveKitBtn_Click(object sender, RoutedEventArgs e)
        {
            var categoryId = kitCategoryCbBox.SelectedValue;
            var name = kitNameTxtBox.Text;
            var breif = kitBriefTxtBox.Text;
            var description = kitDescriptionTxtBox.Text;
            var price = kitPriceTxtBox.Text;
            var purchaseCost = kitPurchaseCostTxtBox.Text;
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

            var kitUpdateDTO = new KitUpdateDTO
            {
                Id = KitId,
                CategoryId = (int)categoryId,
                Name = name,
                Breif = breif,
                Description = description,
                Price = parsedPrice,
                PurchaseCost = parsedPurchaseCost,
                ImageUrl = kitImgBtn.Content.ToString(),
            };
            var result = _kitService.Update(kitUpdateDTO);
            if (result)
            {
                Close();
                KitLoaded(sender, e);
            }
            else
            {
                MessageBox.Show("Failed to update kit");
            }
        }
    }
}
