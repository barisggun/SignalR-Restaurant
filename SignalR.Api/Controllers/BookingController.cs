using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.BookingDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking Booking = new Booking()
            {
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                PersonCount = createBookingDto.PersonCount
            };
            _BookingService.TAdd(Booking);
            return Ok("Booking added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _BookingService.TGetByID(id);
            _BookingService.TDelete(values);

            return Ok("Booking deleted");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking Booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount
            };
            _BookingService.TUpdate(Booking);
            return Ok("Booking updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
