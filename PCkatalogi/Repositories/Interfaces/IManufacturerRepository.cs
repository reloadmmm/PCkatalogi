using PCkatalogi.Models;

namespace PCkatalogi.Repositories.Interfaces
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        Task<Manufacturer?> GetByNameAsync(string name);
        Task<IEnumerable<Manufacturer>> GetManufacturersWithComponentsAsync();
    }
}