using AutoMapper;
using PCkatalogi.DTOs;
using PCkatalogi.Models;
using PCkatalogi.Repositories.Interfaces;

namespace PCkatalogi.Services
{
    /// <summary>
    /// Сервис для проверки совместимости компонентов
    /// </summary>
    public class CompatibilityService : ICompatibilityService
    {
        private readonly ICompatibilityRuleRepository _compatibilityRuleRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса совместимости
        /// </summary>
        public CompatibilityService(
            ICompatibilityRuleRepository compatibilityRuleRepository,
            IComponentRepository componentRepository,
            IMapper mapper)
        {
            _compatibilityRuleRepository = compatibilityRuleRepository;
            _componentRepository = componentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Проверить совместимость двух компонентов
        /// </summary>
        public async Task<CompatibilityCheckDto> CheckComponentsCompatibilityAsync(int sourceComponentId, int targetComponentId)
        {
            var sourceComponent = await _componentRepository.GetComponentWithDetailsAsync(sourceComponentId);
            var targetComponent = await _componentRepository.GetComponentWithDetailsAsync(targetComponentId);

            if (sourceComponent == null || targetComponent == null)
            {
                return new CompatibilityCheckDto
                {
                    SourceComponentId = sourceComponentId,
                    TargetComponentId = targetComponentId,
                    IsCompatible = false,
                    Message = "Один или оба компонента не найдены"
                };
            }

            var isCompatible = await _compatibilityRuleRepository.CheckCompatibilityAsync(sourceComponentId, targetComponentId);
            var rules = await _compatibilityRuleRepository.GetRulesForComponentsAsync(sourceComponentId, targetComponentId);

            return new CompatibilityCheckDto
            {
                SourceComponentId = sourceComponentId,
                TargetComponentId = targetComponentId,
                IsCompatible = isCompatible,
                Message = isCompatible ? "Компоненты совместимы" : "Компоненты не совместимы",
                Rules = _mapper.Map<List<CompatibilityRuleDto>>(rules)
            };
        }

        /// <summary>
        /// Получить все правила совместимости
        /// </summary>
        public async Task<IEnumerable<CompatibilityRuleDto>> GetAllCompatibilityRulesAsync()
        {
            var rules = await _compatibilityRuleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompatibilityRuleDto>>(rules);
        }

        /// <summary>
        /// Создать новое правило совместимости
        /// </summary>
        public async Task<CompatibilityRuleDto> CreateCompatibilityRuleAsync(CreateCompatibilityRuleDto createRuleDto)
        {
            var rule = _mapper.Map<CompatibilityRule>(createRuleDto);
            var createdRule = await _compatibilityRuleRepository.AddAsync(rule);
            return _mapper.Map<CompatibilityRuleDto>(createdRule);
        }
    }
}