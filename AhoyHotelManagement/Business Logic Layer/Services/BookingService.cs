using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS.Booking;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AhoyHotelManagement.Business_Logic_Layer.Services
{
    public interface IBookingService
    {
        Task<BookingResponseDto> BookHotel(BookHotelDto bookHotelDto);
    }

    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUsers> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BookingResponseDto> BookHotel(BookHotelDto bookHotelDto)
        {
            try
            {
                var bookingEntry = _mapper.Map<BookHotelDto, Booking>(bookHotelDto);
                await _unitOfWork.bookingRepository.AddAsync(bookingEntry);
                _unitOfWork.Save();
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; ;
                var user = await _userManager.FindByIdAsync(userId);
                BookingResponseDto response = new BookingResponseDto
                {
                    Status = "Success",
                    Message = "Your hotel booking has been completed.",
                    UserName = user.UserName,
                    HotelName = bookingEntry.Room.Hotels.Name,
                    RoomNumber = bookingEntry.Room.RoomNumber
                };
                return response;
            }
            catch (Exception ex)
            {
                return new BookingResponseDto { Status = "Unxpected Error", Message = ex.ToString() };
            }
           
        }
    }
}
