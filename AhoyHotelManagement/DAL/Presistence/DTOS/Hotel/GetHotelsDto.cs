using AhoyHotelManagement.CommonUtils;

namespace AhoyHotelManagement.DAL.Presistence.DTOS.Hotel
{
    public class GetHotelsDto : BaseResponse
    {
        public GetHotelsDto()
        {
            hotelDto = new List<HotelDto>();
        }
       public List<HotelDto> hotelDto { get; set; }
    }
    public class HotelDto
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
