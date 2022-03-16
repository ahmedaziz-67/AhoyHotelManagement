namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class Facilitiy
    {
        public Facilitiy()
        {
            Facilities = new List<HotelFacilities>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public List<HotelFacilities> Facilities { get; set; }
    }
}
