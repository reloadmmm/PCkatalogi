using PCkatalogi.Models;

namespace PCkatalogi.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
        Task<IEnumerable<Category>> GetCategoriesWithComponentsAsync();
    }
}