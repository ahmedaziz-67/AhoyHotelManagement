using AhoyHotelManagement.CommonUtils;

namespace AhoyHotelManagement.DAL.Presistence.DTOS.Booking
{
    public class BookingResponseDto : BaseResponse
    {
        public string UserName { get; set; }
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }
    }
}
