namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class Hotel
    {
        public Hotel()
        {
            Id = Guid.NewGuid();
        }
       
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public  List<HotelImage> Images { get; set; }
        public string Location { get; set; } = String.Empty;
        public string Rating { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public bool Vacancies { get; set; }
        public  List<Room> Rooms { get; set; }
        public List<HotelFacilities> Facilities { get; set; }
        public string Website { get; set; }
    }
 
}
