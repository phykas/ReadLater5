using Microsoft.EntityFrameworkCore;
using ReadLater.Bookmarks.Application;
using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Domain;
using ReadLater.Bookmarks.EntityFramework.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        private ReadLaterDataContext _readLaterDataContext;
        private readonly IBookmarksMapperService _mapperService;

        public CategoryRepository(ReadLaterDataContext readLaterDataContext, IBookmarksMapperService mapperService)
        {
            _readLaterDataContext = readLaterDataContext;
            _mapperService = mapperService;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            var categoryEntity = _readLaterDataContext.Add(_mapperService.Map<CategoryDto, Category>(category));
            await _readLaterDataContext.SaveChangesAsync();
            return _mapperService
                .Map<Category, CategoryDto>(categoryEntity.Entity);
        }

        public async Task<IEnumerable<CategoryDto>> GetByUserIdAsync(string userId)
        {
            return _mapperService
                .Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(
                await _readLaterDataContext.Categories.Where(e => e.UserId == userId).ToListAsync());
        }

        public async Task<CategoryDto> GetAsync(string userId, int id)
        {
            return _mapperService
                .Map<Category, CategoryDto>(await _readLaterDataContext.Categories.Where(c => c.UserId == userId && c.Id == id).FirstOrDefaultAsync());
        }

        public async Task<CategoryDto> GetAsync(string userId, string name)
        {
            return _mapperService
                .Map<Category, CategoryDto>(await _readLaterDataContext.Categories.Where(c => c.UserId == userId && c.Name == name).FirstOrDefaultAsync());
        }

        public Task UpdateAsync(CategoryDto category)
        {
            _readLaterDataContext.Update(_mapperService.Map<CategoryDto, Category>(category));
            return _readLaterDataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CategoryDto categoryDto)
        {
            var category = await _readLaterDataContext.Categories.FirstOrDefaultAsync(e => e.Id == categoryDto.Id);
            if (category == null)
            {
                return;
            }
            _readLaterDataContext.Categories.Remove(category);
            await _readLaterDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> SearchAsync(string userId, string query)
        {
            return _mapperService
                .Map<IEnumerable<Category>, IEnumerable<CategoryDto>>
                (await _readLaterDataContext.Categories.Where(e => e.UserId == userId && EF.Functions.Like(e.Name, $"%{query}%")).Take(10).ToListAsync());
        }
    }
}
