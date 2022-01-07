using ReadLater.Bookmarks.Authentication;
using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUserService;

        public CategoryService(ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
        {
            _categoryRepository = categoryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            var currentUser = await _currentUserService.Retrieve();
            return await _categoryRepository.GetByUserIdAsync(currentUser.Id);
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var currentUser = await _currentUserService.Retrieve();
            return await _categoryRepository.GetAsync(currentUser.Id, id);
        }

        public async Task<CategoryDto> GetAsync(string name)
        {
            var currentUser = await _currentUserService.Retrieve();
            return await _categoryRepository.GetAsync(currentUser.Id, name);
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            var currentUser = await _currentUserService.Retrieve();
            category.UserId = currentUser.Id;
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(CategoryDto category)
        {
            var currentUser = await _currentUserService.Retrieve();
            category.UserId = currentUser.Id;
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task UpdateAsync(CategoryDto category)
        {
            var currentUser = await _currentUserService.Retrieve();
            category.UserId = currentUser.Id;
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task<IEnumerable<CategoryDto>> SearchAsync(string query)
        {
            var currentUser = await _currentUserService.Retrieve();
            return await _categoryRepository.SearchAsync(currentUser.Id, query);
        }
    }
}
