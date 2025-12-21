using PCkatalogi.DTOs;

namespace PCkatalogi.Services
{
    /// <summary>
    /// Сервис для проверки совместимости компонентов
    /// </summary>
    public interface ICompatibilityService
    {
        /// <summary>
        /// Проверить совместимость двух компонентов
        /// </summary>
        Task<CompatibilityCheckDto> CheckComponentsCompatibilityAsync(int sourceComponentId, int targetComponentId);

        /// <summary>
        /// Получить все правила совместимости
        /// </summary>
        Task<IEnumerable<CompatibilityRuleDto>> GetAllCompatibilityRulesAsync();

        /// <summary>
        /// Создать новое правило совместимости
        /// </summary>
        Task<CompatibilityRuleDto> CreateCompatibilityRuleAsync(CreateCompatibilityRuleDto createRuleDto);
    }
}