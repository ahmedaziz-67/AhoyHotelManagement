using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain;
using AhoyHotelManagement.DAL.Domain.Models;

namespace AhoyHotelManagement.DAL.Presistence.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
    }

    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelContext context)
          : base(context)
        {

        }
    }
}
