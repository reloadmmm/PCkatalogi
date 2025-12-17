using Microsoft.EntityFrameworkCore;
using PCkatalogi.Data;
using PCkatalogi.Models;
using PCkatalogi.Repositories.Interfaces;

namespace PCkatalogi.Repositories.Implementations
{
    public class CompatibilityRuleRepository : BaseRepository<CompatibilityRule>, ICompatibilityRuleRepository
    {
        public CompatibilityRuleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CompatibilityRule>> GetRulesByTypeAsync(string compatibilityType)
        {
            return await _dbSet
                .Where(r => r.CompatibilityType == compatibilityType)
                .Include(r => r.SourceComponent)
                .Include(r => r.TargetComponent)
                .Include(r => r.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<CompatibilityRule>> GetRulesForComponentsAsync(int sourceComponentId, int targetComponentId)
        {
            return await _dbSet
                .Where(r => r.SourceComponentId == sourceComponentId && r.TargetComponentId == targetComponentId)
                .Include(r => r.SourceComponent)
                .Include(r => r.TargetComponent)
                .ToListAsync();
        }

        public async Task<bool> CheckCompatibilityAsync(int sourceComponentId, int targetComponentId)
        {
            var rules = await GetRulesForComponentsAsync(sourceComponentId, targetComponentId);
            return rules.Any(r =>
                (r.RequiredValue == null ||
                 (r.SourceComponent != null &&
                  ((r.CompatibilityType == "SocketMatch" && r.SourceComponent.CpuSocket == r.RequiredValue) ||
                   (r.CompatibilityType == "ProtocolMatch" && r.SourceComponent.Protocols.Any(p => p.Name == r.RequiredValue)))) &&
                (r.RequiredTargetValue == null ||
                 (r.TargetComponent != null &&
                  ((r.CompatibilityType == "SocketMatch" && r.TargetComponent.MotherboardSocket == r.RequiredTargetValue) ||
                   (r.CompatibilityType == "ProtocolMatch" && r.TargetComponent.Protocols.Any(p => p.Name == r.RequiredTargetValue)))))));
        }
    }
}