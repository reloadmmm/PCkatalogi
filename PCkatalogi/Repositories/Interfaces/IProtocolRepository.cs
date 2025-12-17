using PCkatalogi.Models;

namespace PCkatalogi.Repositories.Interfaces
{
    public interface IProtocolRepository : IRepository<Protocol>
    {
        Task<Protocol?> GetByNameAsync(string name);
        Task<IEnumerable<Component>> GetComponentsByProtocolIdAsync(int protocolId);
    }
}