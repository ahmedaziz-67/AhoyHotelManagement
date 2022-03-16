using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS.Booking;
using AutoMapper;

namespace AhoyHotelManagement.DAL.Helpers.Mapping.BookingHotels
{
    public class BookHotelToDomain : Profile
    {
        public BookHotelToDomain()
        {
            CreateMap<BookHotelDto, Booking>()
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(x => x.CardNumber, opt => opt.MapFrom(src => src.CardNumber))
                .ForMember(x => x.CardBin, opt => opt.MapFrom(src => src.CardBin))
                .ForMember(x => x.RoomId, opt => opt.MapFrom(src => src.RoomId));
        }
    }
}
