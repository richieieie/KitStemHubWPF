using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;
using System.Collections.ObjectModel;
using System.Windows;

namespace KitStemHub.App
{
    public partial class CategoryWindow : Window
    {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<CategoryDTO> Categories { get; set; }

        public CategoryWindow(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            Categories = new ObservableCollection<CategoryDTO>();
            CategoryDataGrid.ItemsSource = Categories;

            LoadCategoriesAsync();
        }

        private async void LoadCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newCategory = new CategoryDTO
            {
                Id = int.TryParse(txtCategoryId.Text, out int id) ? id : 0, // Use 0 or handle invalid input appropriately
                Name = txtCategoryName.Text, // or get from a text field
                Status = true
            };

            if (await _categoryService.CreateCategoryAsync(newCategory))
            {
                Categories.Add(newCategory);
            }
        }



        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryDataGrid.SelectedItem is CategoryDTO selectedCategory)
            {
                selectedCategory.Name = txtCategoryName.Text;
                selectedCategory.Status = chkCategoryStatus.IsChecked ?? false;

                await _categoryService.UpdateCategoryAsync(selectedCategory.Id, selectedCategory);
                CategoryDataGrid.Items.Refresh();
                ClearFields();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryDataGrid.SelectedItem is CategoryDTO selectedCategory)
            {
                if (await _categoryService.DeleteCategoryAsync(selectedCategory.Id))
                {
                    Categories.Remove(selectedCategory);
                    ClearFields();
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            chkCategoryStatus.IsChecked = false;
            CategoryDataGrid.SelectedItem = null; 
        }


        private void CategoryDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CategoryDataGrid.SelectedItem is CategoryDTO selectedCategory)
            {
                txtCategoryId.Text = selectedCategory.Id.ToString();
                txtCategoryName.Text = selectedCategory.Name;
                chkCategoryStatus.IsChecked = selectedCategory.Status;
            }
        }

    }
}
