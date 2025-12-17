using PCkatalogi.Models;

namespace PCkatalogi.Repositories.Interfaces
{
    public interface IComponentRepository : IRepository<Component>
    {
        Task<IEnumerable<Component>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Component>> GetByManufacturerIdAsync(int manufacturerId);
        Task<IEnumerable<Component>> GetComponentsWithDetailsAsync();
        Task<Component?> GetComponentWithDetailsAsync(int id);
    }
}