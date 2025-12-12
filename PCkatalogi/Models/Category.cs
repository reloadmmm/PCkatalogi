using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCkatalogi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Component> Components { get; set; } = new List<Component>();
        public virtual ICollection<CompatibilityRule> CompatibilityRules { get; set; } = new List<CompatibilityRule>();
    }
}