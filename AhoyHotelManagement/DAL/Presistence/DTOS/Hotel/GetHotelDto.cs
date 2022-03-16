namespace AhoyHotelManagement.DAL.Presistence.DTOS.Hotel
{
    public class GetHotelDto
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<HotelFacilitiesDto> Facilities { get; set; }
        public decimal Price { get; set; }
        public List<HotelImagesDto> Images { get; set; }
    }
    public class HotelFacilitiesDto
    {
        public string Name { get; set; }
    }
    public class HotelImagesDto
    {
        public string ImagePath { get; set; }
    }
}
