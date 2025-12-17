using Microsoft.EntityFrameworkCore;
using PCkatalogi.Data;
using PCkatalogi.Models;
using PCkatalogi.Repositories.Interfaces;

namespace PCkatalogi.Repositories.Implementations
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Manufacturer?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturersWithComponentsAsync()
        {
            return await _dbSet
                .Include(m => m.Components)
                .ThenInclude(c => c.Category)
                .ToListAsync();
        }
    }
}