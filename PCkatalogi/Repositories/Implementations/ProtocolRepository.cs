using Microsoft.EntityFrameworkCore;
using PCkatalogi.Data;
using PCkatalogi.Models;
using PCkatalogi.Repositories.Interfaces;

namespace PCkatalogi.Repositories.Implementations
{
    public class ProtocolRepository : BaseRepository<Protocol>, IProtocolRepository
    {
        public ProtocolRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Protocol?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Component>> GetComponentsByProtocolIdAsync(int protocolId)
        {
            return await _context.Components
                .Where(c => c.Protocols.Any(p => p.Id == protocolId))
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .ToListAsync();
        }
    }
}