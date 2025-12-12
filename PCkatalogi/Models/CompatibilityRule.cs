using System.ComponentModel.DataAnnotations;

namespace PCkatalogi.Models
{
    public class CompatibilityRule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string RuleName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        [StringLength(50)]
        public string CompatibilityType { get; set; } = string.Empty; 

        public int SourceComponentId { get; set; } 
        public int TargetComponentId { get; set; } 
        public int CategoryId { get; set; } 

        [StringLength(200)]
        public string? RequiredValue { get; set; } 
        [StringLength(200)]
        public string? RequiredTargetValue { get; set; } 

        public virtual Component SourceComponent { get; set; } = null!;
        public virtual Component TargetComponent { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}