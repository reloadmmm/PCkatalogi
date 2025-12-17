using Microsoft.EntityFrameworkCore;
using PCkatalogi.Data;
using PCkatalogi.Models;
using PCkatalogi.Repositories.Interfaces;

namespace PCkatalogi.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithComponentsAsync()
        {
            return await _dbSet
                .Include(c => c.Components)
                .ThenInclude(comp => comp.Manufacturer)
                .ToListAsync();
        }
    }
}