using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<CategoryDto> CreateCategoryAsync(CategoryDto category)
        {
            return _categoryRepository.CreateCategoryAsync(category);
        }

        public Task DeleteCategoryAsync(CategoryDto category)
        {
            return _categoryRepository.DeleteCategoryAsync(category);
        }

        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return _categoryRepository.GetCategoriesAsync();
        }

        public Task<CategoryDto> GetCategoryAsync(int id)
        {
            return _categoryRepository.GetCategoryAsync(id);
        }

        public Task<CategoryDto> GetCategoryAsync(string name)
        {
            return _categoryRepository.GetCategoryAsync(name);
        }

        public Task UpdateCategoryAsync(CategoryDto category)
        {
            return _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
