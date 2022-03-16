namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class HotelImage
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } 
        public virtual Hotel Hotels { get; set; }
    }
}
