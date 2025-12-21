namespace PCkatalogi.DTOs
{
    public class CreateProtocolDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Version { get; set; }
    }

    public class UpdateProtocolDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Version { get; set; }
    }

    public class ProtocolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Version { get; set; }
    }
}