using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS;
using AhoyHotelManagement.DAL.Presistence.DTOS.Hotel;
using AutoMapper;

namespace AhoyHotelManagement.Business_Logic_Layer.Services
{
    #region Service
    public interface IHotelService
    {
        Task<GetHotelsDto> GetAllHotels(PaginationParameters paginationParameters);
        Task CreateHotel(CreateHotelDto createHotelDto);
        Task<GetHotelDto> GetHotel(Guid Id);
        Task<GetHotelsDto> GetFilteredHotels(string FilterName, string FilterValue);
    }
    #endregion
    #region Implementation
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HotelService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateHotel(CreateHotelDto createHotelDto)
        {
            
                var hotelEntry = _mapper.Map<CreateHotelDto, Hotel>(createHotelDto);
                await _unitOfWork.hotelRepository.AddAsync(hotelEntry);
                _unitOfWork.Save();
         
        }
 

        public async Task<GetHotelsDto> GetAllHotels(PaginationParameters paginationParameters)
        {
            try {
                var pagedHotel = await _unitOfWork.hotelRepository.GetPagedList(paginationParameters);
                var result = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDto>>(pagedHotel);
                GetHotelsDto getHotelsDto = new GetHotelsDto
                {
                    hotelDto = result.ToList(),
                    Status = "Success",
                    Message = "This is all avaliable hotels right now"
                };
                return getHotelsDto;
            }
            catch (Exception ex)
            {
                return new GetHotelsDto { Status = "Unexpected Error", Message = ex.ToString() };
            }
            

        }

        public async Task<GetHotelDto> GetHotel(Guid Id)
        {
            try
            {
                var hotelDetails = await _unitOfWork.hotelRepository.GetHotelDetails(Id);
                var result = _mapper.Map<Hotel, GetHotelDto>(hotelDetails);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        public async Task<GetHotelsDto> GetFilteredHotels(string FilterName, string FilterValue)
        {
            GetHotelsDto getHotelsDto = new GetHotelsDto();
            switch (FilterName)
            {
                case "ByName":
                    var hotel = await _unitOfWork.hotelRepository.GetHotelsByName(FilterValue);
                    var result = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDto>>(hotel);
                     getHotelsDto = new GetHotelsDto
                    {
                        hotelDto = result.ToList(),
                        Status = "Success",
                        Message = "Here you go."
                    };
                    return getHotelsDto;
                    break;
                case "ByRating":
                     hotel = await _unitOfWork.hotelRepository.GetHotelsByRating(FilterValue);
                     result = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDto>>(hotel);
                     getHotelsDto = new GetHotelsDto
                    {
                        hotelDto = result.ToList(),
                         Status = "Success",
                         Message = "This is all the available hotels with the rating you entered."
                     };
                    return getHotelsDto;
                    break;
                case "ByLocation":
                    hotel = await _unitOfWork.hotelRepository.GetHotelsByLocation(FilterValue);
                    result = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDto>>(hotel);
                    getHotelsDto = new GetHotelsDto
                    {
                        hotelDto = result.ToList(),
                        Status = "Success",
                        Message = "This is all the available hotels with the location you entered."
                    };
                    return getHotelsDto;
                    break;
                default:
                    getHotelsDto = new GetHotelsDto
                    {
                        Status = "Failed",
                        Message = "Invalid filter"
                    };
   break;
            }
            return getHotelsDto = new GetHotelsDto
            {
                Status = "Error",
                Message = "UnexpectedError"
            };
        }
    }
    #endregion
}
