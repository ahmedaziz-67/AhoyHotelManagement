using AhoyHotelManagement.Business_Logic_Layer.Services;
using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS;
using AhoyHotelManagement.DAL.Presistence.DTOS.Hotel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhoiHotelManagementTests.MockData
{
    public class HotelServiceMock : IHotelService
    {
        private readonly List<Hotel> _hotel;
        IMapper _mapper;
        IHotelService _hotelService;
        public HotelServiceMock()
        {
            _hotel = new List<Hotel>()
            {
                new Hotel() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Hotel", Location="Orange street", Price = 5.00M, Description="mock description one",Rating="TwoStars",Vacancies=true,Website="www.orangehotel.com" },
                new Hotel() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Hotel", Location="Co-4thstreet", Price = 4.00M,Description="mock description two",Rating="ThreeStars",Vacancies=true,Website="www.dairyhotel.com" },
                new Hotel() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen lake hotel", Location="Uncle Mickey st", Price = 12.00M,Description="mock description three",Rating="oneStar",Vacancies=true,Website="www.frozenlakehotel.com" }
            };
        }
        public Task CreateHotel(CreateHotelDto createHotelDto)
        {
            var hotelEntry = _mapper.Map<CreateHotelDto, Hotel>(createHotelDto);
            _hotel.Add(hotelEntry);
            return Task.CompletedTask;
        }

        public async Task<GetHotelsDto> GetAllHotels(PaginationParameters paginationParameters)
        {
            var result = await _hotelService.GetAllHotels(paginationParameters);

            return result;
        }

        public Task<GetHotelsDto> GetFilteredHotels(string FilterName, string FilterValue)
        {
            throw new NotImplementedException();
        }

        public async Task<GetHotelDto> GetHotel(Guid Id)
        {
           var getHotel=  _hotel.Where(a => a.Id == Id)
             .FirstOrDefault();
            var result =  _mapper.Map<Hotel, GetHotelDto>(getHotel);
            return result;
        }
    }
}
