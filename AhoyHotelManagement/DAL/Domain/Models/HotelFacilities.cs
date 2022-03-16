using System.ComponentModel.DataAnnotations.Schema;

namespace AhoyHotelManagement.DAL.Domain.Models
{
    public class HotelFacilities
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public Guid FacilitiyId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Facilitiy Facilitiy { get; set; }
    }
}
