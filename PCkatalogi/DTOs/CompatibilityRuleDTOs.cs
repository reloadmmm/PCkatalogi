namespace PCkatalogi.DTOs
{
    public class CreateCompatibilityRuleDto
    {
        public string RuleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string CompatibilityType { get; set; } = string.Empty;
        public int SourceComponentId { get; set; }
        public int TargetComponentId { get; set; }
        public int CategoryId { get; set; }
        public string? RequiredValue { get; set; }
        public string? RequiredTargetValue { get; set; }
    }

    public class UpdateCompatibilityRuleDto
    {
        public string RuleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string CompatibilityType { get; set; } = string.Empty;
        public int SourceComponentId { get; set; }
        public int TargetComponentId { get; set; }
        public int CategoryId { get; set; }
        public string? RequiredValue { get; set; }
        public string? RequiredTargetValue { get; set; }
    }

    public class CompatibilityRuleDto
    {
        public int Id { get; set; }
        public string RuleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string CompatibilityType { get; set; } = string.Empty;
        public ComponentDto? SourceComponent { get; set; }
        public ComponentDto? TargetComponent { get; set; }
        public CategoryDto? Category { get; set; }
        public string? RequiredValue { get; set; }
        public string? RequiredTargetValue { get; set; }
    }

    public class CompatibilityCheckDto
    {
        public int SourceComponentId { get; set; }
        public int TargetComponentId { get; set; }
        public bool IsCompatible { get; set; }
        public string? Message { get; set; }
        public List<CompatibilityRuleDto>? Rules { get; set; }
    }
}