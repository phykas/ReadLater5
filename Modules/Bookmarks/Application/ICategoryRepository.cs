using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> CreateCategoryAsync(CategoryDto category);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<CategoryDto> GetCategoryAsync(string name);
        Task UpdateCategoryAsync(CategoryDto category);
        Task DeleteCategoryAsync(CategoryDto category);
    }
}
