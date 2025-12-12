using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCkatalogi.Models
{
    public class Protocol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty; 

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Version { get; set; }
        public virtual ICollection<Component> Components { get; set; } = new List<Component>();
    }
}