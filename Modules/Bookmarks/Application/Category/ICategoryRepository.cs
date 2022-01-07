using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> CreateAsync(CategoryDto category);
        Task<IEnumerable<CategoryDto>> GetByUserIdAsync(string userId);
        Task<CategoryDto> GetAsync(string userId, int id);
        Task<CategoryDto> GetAsync(string userId, string name);
        Task UpdateAsync(CategoryDto category);
        Task DeleteAsync(CategoryDto category);
        Task<IEnumerable<CategoryDto>> SearchAsync(string userId, string query);
    }
}
