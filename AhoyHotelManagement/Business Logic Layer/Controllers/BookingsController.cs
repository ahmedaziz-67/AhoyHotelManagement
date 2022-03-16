using AhoyHotelManagement.Business_Logic_Layer.Services;
using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Presistence.DTOS.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhoyHotelManagement.Business_Logic_Layer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        /// <summary>
        /// This endpoint for placing a booking.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        [HttpPost("BookHotel")]
        public async Task<ActionResult> BookHotel([FromBody] BookHotelDto booking)
        {
            try
            {
              var result =   await _bookingService.BookHotel(booking);

                return Ok(result);
            }
            catch (Exception e) { return BadRequest( new BaseResponse { Status = "Unxpected Error", Message = e.ToString() }); }

        }
    }
}
