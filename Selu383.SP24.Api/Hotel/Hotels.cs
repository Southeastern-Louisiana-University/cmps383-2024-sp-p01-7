namespace Selu383.SP24.Api.Hotel
{
    public class Hotels
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public required string? Address { get; set; }
    }

    public class HotelsDto
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public required string? Address { get; set; }
    }
}
