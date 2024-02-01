using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Hotel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> ListAllHotels()
        {
            var hotels = await _context.Hotel.ToListAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotelById(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] HotelDto hotelDto)
        {
            if (hotelDto == null)
            {
                return BadRequest("Hotel data is null.");
            }

            if (string.IsNullOrWhiteSpace(hotelDto.Name))
            {
                return BadRequest("Name must be provided.");
            }

            if (hotelDto.Name.Length > 120)
            {
                return BadRequest("Name cannot be longer than 120 characters.");
            }

            if (string.IsNullOrWhiteSpace(hotelDto.Address))
            {
                return BadRequest("Must have an address.");
            }


            var hotelEntity = new Selu383.SP24.Api.Hotel.Hotel { Name = hotelDto.Name, Address = hotelDto.Address };
            _context.Hotel.Add(hotelEntity);
            _context.SaveChanges();


            return CreatedAtAction(nameof(CreateHotel), new { id = hotelEntity.Id }, hotelDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelDto updatedHotelDto)
        {
            if (updatedHotelDto == null)
            {
                return BadRequest("Updated hotel data is null.");
            }

            var existingHotel = await _context.Hotel.FindAsync(id);

            if (existingHotel == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(updatedHotelDto.Name))
            {
                return BadRequest("Name must be provided.");
            }

            if (updatedHotelDto.Name.Length > 120)
            {
                return BadRequest("Name cannot be longer than 120 characters.");
            }

            if (string.IsNullOrWhiteSpace(updatedHotelDto.Address))
            {
                return BadRequest("Must have an address.");
            }

            existingHotel.Name = updatedHotelDto.Name;
            existingHotel.Address = updatedHotelDto.Address;

            await _context.SaveChangesAsync();

            return Ok(new HotelDto { Id = existingHotel.Id, Name = existingHotel.Name, Address = existingHotel.Address });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotelToDelete = await _context.Hotel.FindAsync(id);

            if (hotelToDelete == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(hotelToDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}




