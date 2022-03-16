namespace AhoyHotelManagement.DAL.Presistence.DTOS.Booking
{
    public class BookHotelDto
    {
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public string CardBin { get; set; }
        public Guid RoomId { get; set; }
    }
}
