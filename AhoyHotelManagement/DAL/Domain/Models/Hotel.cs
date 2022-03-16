namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class Hotel
    {
        public Hotel()
        {
            Id = Guid.NewGuid();
            Images = new List<HotelImage>();
            Rooms = new List<Room>();
            Facilities = new List<HotelFacilities>();
        }
       
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public  List<HotelImage> Images { get; set; }
        public string Location { get; set; } 
        public string Rating { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Vacancies { get; set; }
        public  List<Room> Rooms { get; set; }
        public List<HotelFacilities> Facilities { get; set; }
        public string Website { get; set; }
    }
 
}
