namespace AhoyHotelManagement.DAL.Presistence.DTOS
{
    public class CreateHotelDto
    {
        public string Name { get; set; } 
        public string Location { get; set; } 
        public string Rating { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public bool Vacancies { get; set; }
        public string Website { get; set; }
    }
}
