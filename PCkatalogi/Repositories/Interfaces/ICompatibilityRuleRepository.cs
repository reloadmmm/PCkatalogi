using PCkatalogi.Models;

namespace PCkatalogi.Repositories.Interfaces
{
    public interface ICompatibilityRuleRepository : IRepository<CompatibilityRule>
    {
        Task<IEnumerable<CompatibilityRule>> GetRulesByTypeAsync(string compatibilityType);
        Task<IEnumerable<CompatibilityRule>> GetRulesForComponentsAsync(int sourceComponentId, int targetComponentId);
        Task<bool> CheckCompatibilityAsync(int sourceComponentId, int targetComponentId);
    }
}