namespace PCkatalogi.DTOs
{
    public class CreateManufacturerDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? Website { get; set; }
    }

    public class UpdateManufacturerDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? Website { get; set; }
    }

    public class ManufacturerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? Website { get; set; }
    }
}