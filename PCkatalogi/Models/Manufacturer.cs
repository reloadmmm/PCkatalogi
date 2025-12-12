using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCkatalogi.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Country { get; set; }

        [StringLength(200)]
        public string? Website { get; set; }
        public virtual ICollection<Component> Components { get; set; } = new List<Component>();
    }
}