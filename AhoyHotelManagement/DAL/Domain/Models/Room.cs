using System.ComponentModel.DataAnnotations.Schema;

namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public bool IsBooked { get; set; }
        public Guid HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual Hotel Hotels { get; set; }
        public virtual Booking Booking { get; set; }   
    }
}
