using AhoyHotelManagement.Business_Logic_Layer.Services;
using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Presistence.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhoyHotelManagement.Business_Logic_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost("CreateHotel")]
        public async Task<ActionResult> CreateHotel([FromBody] CreateHotelDto hotel)
        {
            try
            {
              await  _hotelService.CreateHotel(hotel);

                return Ok(new BaseResponse { Status="Succuess",Message="Hotel Created Successfuly."});
            }
            catch (Exception e) { return BadRequest(); }

        }

        [HttpPost("GetAllHotels")]
        public async Task<ActionResult> GetAllHotels(PaginationParameters paginationParameters)
        {
            try
            {
                var result = await _hotelService.GetAllHotels(paginationParameters);

                return Ok(result);
            }
            catch (Exception e) { return Ok(); }

        }

        [HttpGet("Id")]
        public async Task<ActionResult> GetHotel(Guid Id)
        {
            try
            {
                var result = await _hotelService.GetHotel(Id);

                return Ok(result);
            }
            catch (Exception e) {return BadRequest(); }

        }
        [HttpGet("FilterHotels")]
        public async Task<ActionResult> FilterHotels(string FilterName,string FilterValue)
        {
            try
            {
                var result = await _hotelService.GetFilteredHotels(FilterName, FilterValue);

                return Ok(result);
            }
            catch (Exception e) { return Ok(); }

        }
    }
}
