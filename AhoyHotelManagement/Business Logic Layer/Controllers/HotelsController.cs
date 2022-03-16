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
        /// <summary>
        /// This endpoint is used to create a hotel in the database.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost("CreateHotel")]
        public async Task<ActionResult> CreateHotel([FromBody] CreateHotelDto hotel)
        {
            try
            {
              await  _hotelService.CreateHotel(hotel);

                return Ok(new BaseResponse { Status="Succuess",Message="Hotel Created Successfuly."});
            }
            catch (Exception e) { return BadRequest(new BaseResponse { Status="Unexpected Error",Message=e.ToString()}); }

        }
        /// <summary>
        /// This endpoint returns a list of all hotels from the database.
        /// The paginationParameters is two numbers passed from the front team to handle 
        /// the size of elements in the page.
        /// </summary>
        /// <param name="paginationParameters"></param>
        /// <returns></returns>
        [HttpPost("GetAllHotels")]
        public async Task<ActionResult> GetAllHotels(PaginationParameters paginationParameters)
        {
            try
            {
                var result = await _hotelService.GetAllHotels(paginationParameters);

                return Ok(result);
            }
            catch (Exception e) { return BadRequest(new BaseResponse { Status = "Unexpected Error", Message = e.ToString() }); }

        }

        /// <summary>
        /// This endpoint is used for getting all the details of a selected hotel
        /// by retrieving all of its info by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetHotel")]
        public async Task<ActionResult> GetHotel(Guid Id)
        {
            try
            {
                var result = await _hotelService.GetHotel(Id);

                return Ok(result);
            }
            catch (Exception e) {return BadRequest(new BaseResponse { Status = "Unexpected Error", Message = e.ToString() }); }

        }

        /// <summary>
        /// This endpoint is used to search a hotel by its name and also filter the list of hotels by rating and location.
        /// eg.: filterName:"ByRating" , FilterValue:"ThreeStars"
        /// </summary>
        /// <param name="FilterName"></param>
        /// <param name="FilterValue"></param>
        /// <returns></returns>
        [HttpGet("FilterHotels")]
        public async Task<ActionResult> FilterHotels(string FilterName,string FilterValue)
        {
            try
            {
                var result = await _hotelService.GetFilteredHotels(FilterName, FilterValue);

                return Ok(result);
            }
            catch (Exception e) { return BadRequest(new BaseResponse { Status = "Unexpected Error", Message = e.ToString() }); }

        }
    }
}
