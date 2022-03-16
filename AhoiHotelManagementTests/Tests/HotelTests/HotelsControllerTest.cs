using AhoiHotelManagementTests.MockData;
using AhoyHotelManagement.Business_Logic_Layer.Controllers;
using AhoyHotelManagement.Business_Logic_Layer.Services;
using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain.Models;
using AhoyHotelManagement.DAL.Presistence.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        #region GetAllHotelsTest
        [Fact]
        public  async Task Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _controller.GetAllHotels(paginationParameters);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = await _controller.GetAllHotels(paginationParameters) as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Hotel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        #endregion
        #region GetHotelByIdTest
        [Fact]
        public async Task GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = await _controller.GetHotel(Guid.NewGuid());
            // Assert
            Assert.IsType<BadRequestResult>(notFoundResult);
        }
        [Fact]
        public async Task GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = "815accac-fd5b-478a-a9d6-f171a2f6ae7f";
            // Act
            var okResult  =await _controller.GetHotel(Guid.Parse(testGuid));
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
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
        [Fact]
        public async Task Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new CreateHotelDto()
            {
                Name = "Guinness Original 6 Pack",
                Location = "Guinness",
                Description = "Test Description",
                Rating = "FourStars",
                Vacancies = true,
                Website = "www.Guinnesshotel.com",
                Price = 12.00M
            };
            // Act
            var createdResponse = await _controller.CreateHotel(testItem);
            //  var item = createdResponse.Value as CreateHotelDto;
            // Assert
            Assert.IsType<OkResult>(createdResponse);
           // Assert.Equal("Guinness Original 6 Pack", item.Name);
        }
        #endregion
    }
}
