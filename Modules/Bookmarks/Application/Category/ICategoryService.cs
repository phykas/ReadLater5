using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CategoryDto category);
        Task<IEnumerable<CategoryDto>> GetAsync();
        Task<CategoryDto> GetAsync(int id);
        Task<CategoryDto> GetAsync(string name);
        Task<IEnumerable<CategoryDto>> SearchAsync(string query);
        Task UpdateAsync(CategoryDto category);
        Task DeleteAsync(CategoryDto category);
    }
}
