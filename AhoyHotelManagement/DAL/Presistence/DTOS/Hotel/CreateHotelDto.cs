namespace AhoyHotelManagement.DAL.Presistence.DTOS
{
    public class CreateHotelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool Vacancies { get; set; }
        public string Website { get; set; }
    }
}
