namespace PCkatalogi.DTOs
{
    public class CreateComponentDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public string? CpuSocket { get; set; }
        public string? MotherboardSocket { get; set; }
        public string? MemoryType { get; set; }
        public string? FormFactor { get; set; }
        public List<int>? ProtocolIds { get; set; } = new List<int>();
    }

    public class UpdateComponentDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public string? CpuSocket { get; set; }
        public string? MotherboardSocket { get; set; }
        public string? MemoryType { get; set; }
        public string? FormFactor { get; set; }
        public List<int>? ProtocolIds { get; set; } = new List<int>();
    }

    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CategoryDto? Category { get; set; }
        public ManufacturerDto? Manufacturer { get; set; }
        public string? CpuSocket { get; set; }
        public string? MotherboardSocket { get; set; }
        public string? MemoryType { get; set; }
        public string? FormFactor { get; set; }
        public List<ProtocolDto> Protocols { get; set; } = new List<ProtocolDto>();
    }
}