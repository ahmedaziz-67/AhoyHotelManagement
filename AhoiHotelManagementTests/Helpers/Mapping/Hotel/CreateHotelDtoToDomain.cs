using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS;
using AutoMapper;

namespace AhoyHotelManagement.DAL.Helpers.Mapping
{
    public class CreateHotelDtoToDomain : Profile
    {
        public CreateHotelDtoToDomain()
        {
            CreateMap<CreateHotelDto, Hotel>();
        }
    }
}
