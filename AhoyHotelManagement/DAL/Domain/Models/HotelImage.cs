namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class HotelImage
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = String.Empty;
        public virtual Hotel Hotels { get; set; }
    }
}
