namespace Selu383.SP24.Api.Hotel
{
    public class Hotel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
    }

    public class HotelDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
    }
}
