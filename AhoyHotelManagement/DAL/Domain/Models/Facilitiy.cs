namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class Facilitiy
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<HotelFacilities> Facilities { get; set; }
    }
}
