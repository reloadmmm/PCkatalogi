using Microsoft.EntityFrameworkCore;
using PCkatalogi.Data;
using PCkatalogi.Models;
using PCkatalogi.Repositories.Interfaces;

namespace PCkatalogi.Repositories.Implementations
{
    public class ComponentRepository : BaseRepository<Component>, IComponentRepository
    {
        public ComponentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Component>> GetByCategoryIdAsync(int categoryId)
        {
            return await _dbSet
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Component>> GetByManufacturerIdAsync(int manufacturerId)
        {
            return await _dbSet
                .Where(c => c.ManufacturerId == manufacturerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Component>> GetComponentsWithDetailsAsync()
        {
            return await _dbSet
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .Include(c => c.Protocols)
                .ToListAsync();
        }

        public async Task<Component?> GetComponentWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .Include(c => c.Protocols)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}