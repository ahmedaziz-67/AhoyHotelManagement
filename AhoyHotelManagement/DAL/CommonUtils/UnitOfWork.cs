using AhoyHotelManagement.DAL.Domain;
using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.Repositories;

namespace AhoyHotelManagement.CommonUtils
{
    public interface IUnitOfWork
    {
        IHotelRepository hotelRepository { get; }
        IBookingRepository bookingRepository { get; }
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private IHotelRepository _hotelRepository;
        private IBookingRepository _bookingRepository;
        private HotelContext _context;
        public UnitOfWork(HotelContext context)
        {
            _context = context;
        }
        public IHotelRepository hotelRepository
        {
            get
            {
                if (_hotelRepository == null)
                {
                    _hotelRepository = new HotelRepository(_context);
                }

                return _hotelRepository;
            }
        }
        public IBookingRepository bookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_context);
                }

                return _bookingRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
