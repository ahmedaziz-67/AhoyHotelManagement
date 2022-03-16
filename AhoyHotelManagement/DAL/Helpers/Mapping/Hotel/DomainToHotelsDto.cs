using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS.Hotel;
using AutoMapper;

namespace AhoyHotelManagement.DAL.Helpers.Mapping
{
    public class DomainToHotelsDto : Profile
    {
        public DomainToHotelsDto()
        {
            CreateMap<HotelFacilities, HotelFacilitiesDto>()
                .ForMember(x=>x.Name,opt=>opt.MapFrom(src=>src.Facilitiy.Name));
            CreateMap<HotelImage, HotelImagesDto>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<Hotel, GetHotel>();
        }
    }
}
