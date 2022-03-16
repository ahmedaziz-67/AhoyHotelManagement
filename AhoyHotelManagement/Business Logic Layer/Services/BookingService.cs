using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS.Booking;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AhoyHotelManagement.Business_Logic_Layer.Services
{
    #region Service
    public interface IBookingService
    {
        Task<BookingResponseDto> BookHotel(BookHotelDto bookHotelDto);
    }
    #endregion
    #region Implementation
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
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
                var bookingEntry = _mapper.Map<BookHotelDto, Booking>(bookHotelDto);
                bookingEntry.UserId = userId;
                await _unitOfWork.bookingRepository.AddAsync(bookingEntry);
                _unitOfWork.Save();
                BookingResponseDto response = new BookingResponseDto
                {
                    Status = "Success",
                    Message = "Your hotel booking has been completed."
                };
                return response;
            }
            catch (Exception ex)
            {
                return new BookingResponseDto { Status = "Unxpected Error", Message = ex.ToString() };
            }
           
        }
    }
    #endregion
}
