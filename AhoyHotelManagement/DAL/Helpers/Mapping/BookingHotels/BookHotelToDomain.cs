using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS.Booking;
using AutoMapper;

namespace AhoyHotelManagement.DAL.Helpers.Mapping.BookingHotels
{
    public class BookHotelToDomain : Profile
    {
        public BookHotelToDomain()
        {
            CreateMap<BookHotelDto, Booking>();
        }
    }
}
