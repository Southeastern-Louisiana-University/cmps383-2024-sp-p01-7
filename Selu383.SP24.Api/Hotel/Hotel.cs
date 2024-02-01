using System.ComponentModel.DataAnnotations;

namespace Selu383.SP24.Api.Hotel
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }
    }

    public class HotelDto
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
