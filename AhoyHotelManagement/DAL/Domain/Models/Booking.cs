using System.ComponentModel.DataAnnotations.Schema;

namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class Booking
    {
        public Booking()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardBin { get; set; }
        public string PhoneNumber { get; set; } 
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUsers Users { get; set; }
    }
}
