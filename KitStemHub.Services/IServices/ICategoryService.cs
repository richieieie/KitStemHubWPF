using KitStemHub.Services.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitStemHub.Services.IServices
{
    public interface ICategoryService
    {
        // Get all categories
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();

        // Get a category by its Id
        Task<CategoryDTO?> GetCategoryByIdAsync(int id);

        // Create a new category
        Task<bool> CreateCategoryAsync(CategoryDTO categoryDTO);

        // Update an existing category
        Task<bool> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);

        // Delete a category by Id
        Task<bool> DeleteCategoryAsync(int id);
    }
}
