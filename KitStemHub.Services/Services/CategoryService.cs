using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Repositories.Repositories;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitStemHub.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category != null ? _mapper.Map<CategoryDTO>(category) : null;
        }

        public async Task<bool> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            _categoryRepository.PrepareCreate(category);
            return await _categoryRepository.SaveAsync();
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return false;

            _mapper.Map(categoryDTO, category);  // Updates existing entity with new values
            _categoryRepository.PrepareUpdate(category);
            return await _categoryRepository.SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return false;

            _categoryRepository.PrepareRemove(category);
            return await _categoryRepository.SaveAsync();
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
