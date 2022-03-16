using AhoiHotelManagementTests.MockData;
using AhoyHotelManagement.Business_Logic_Layer.Controllers;
using AhoyHotelManagement.Business_Logic_Layer.Services;
using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Presistence.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AhoiHotelManagementTests.Tests.HotelTests
{
    public class HotelsControllerTest
    {
        PaginationParameters paginationParameters = new PaginationParameters { PageNumber = 1, PageSize = 10 };
        private readonly HotelsController _controller;
        private readonly IHotelService _service;
        public HotelsControllerTest()
        {
            _service = new HotelServiceMock();
            _controller = new HotelsController(_service);
        }
      
        #region GetHotelByIdTest
        [Fact]
        public async Task GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = await _controller.GetHotel(Guid.NewGuid());
            // Assert
            Assert.IsType<BadRequestResult>(notFoundResult);
        }
      
        #endregion
        #region CreateHotelTest
        [Fact]
        public async Task Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new CreateHotelDto()
            {
               // Name = "Guinness",
                Price = 12.00M
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse =await _controller.CreateHotel(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }
       
        #endregion
    }
}
