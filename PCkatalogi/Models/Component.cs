using System.ComponentModel.DataAnnotations;

namespace PCkatalogi.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }

        [StringLength(50)]
        public string? CpuSocket { get; set; }
        [StringLength(50)]
        public string? MotherboardSocket { get; set; }
        [StringLength(50)]
        public string? MemoryType { get; set; } 
        [StringLength(50)]
        public string? FormFactor { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        public virtual ICollection<Protocol> Protocols { get; set; } = new List<Protocol>();

        public virtual ICollection<CompatibilityRule> SourceComponents { get; set; } = new List<CompatibilityRule>();
        public virtual ICollection<CompatibilityRule> TargetComponents { get; set; } = new List<CompatibilityRule>();
    }
}