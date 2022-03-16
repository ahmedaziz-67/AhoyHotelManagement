using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain;
using AhoyHotelManagement.DAL.Domain.Models;

namespace AhoyHotelManagement.DAL.Presistence.Repositories
{
    #region Interface
    public interface IBookingRepository : IBaseRepository<Booking>
    {
    }
    #endregion
    #region Implementation
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelContext context)
          : base(context)
        {

        }
    }
    #endregion
}
