using Application.IServices;
using Application.ViewModels.BookingViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace VinsportWebAPI.Controllers
{
    [Route("odata")]
    public class BookingController : ODataController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [EnableQuery]
        [HttpGet("Bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _bookingService.GetAllBookings());
        }

        [HttpPost("Bookings")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO createBookingDTO)
        {
            bool isCreated = await _bookingService.CreateBookingAsync(createBookingDTO);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Bookings")]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingDTO updateBookingDTO)
        {
            bool isUpdated = await _bookingService.UpdateBookingAsync(updateBookingDTO);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [EnableQuery]
        [HttpGet("Bookings({id})")]
        public async Task<IActionResult> GetBooking([FromRoute] Guid id)
        {
            Booking findBooking = await _bookingService.GetBookingByIdAsync(id);
            if (findBooking != null)
            {
                return Ok(findBooking);
            }
            return BadRequest();
        }

        [HttpDelete("Bookings({id})")]
        public async Task<IActionResult> DeleteBooking([FromRoute] Guid id)
        {
            try
            {
                if (await _bookingService.SoftRemoveBookingAsync(id))
                {
                    return Ok("Soft Remove Booking successfully");
                }
                else
                {
                    throw new Exception("Saving fail");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Soft Remove Booking failed: " + ex.Message);
            }
        }
    }
}
