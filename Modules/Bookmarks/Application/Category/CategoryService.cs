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

        public Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            return _categoryRepository.CreateAsync(category);
        }

        public Task DeleteAsync(CategoryDto category)
        {
            return _categoryRepository.DeleteAsync(category);
        }

        public Task<IEnumerable<CategoryDto>> GetAsync()
        {
            return _categoryRepository.GetAsync();
        }

        public Task<CategoryDto> GetAsync(int id)
        {
            return _categoryRepository.GetAsync(id);
        }

        public Task<CategoryDto> GetAsync(string name)
        {
            return _categoryRepository.GetAsync(name);
        }

        public Task UpdateAsync(CategoryDto category)
        {
            return _categoryRepository.UpdateAsync(category);
        }

        Task<IEnumerable<CategoryDto>> ICategoryService.SearchAsync(string query)
        {
            return _categoryRepository.SearchAsync(query);
        }
    }
}
