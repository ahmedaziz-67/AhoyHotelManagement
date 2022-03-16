using AhoyHotelManagement.DAL.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AhoyHotelManagement.DAL.Domain
{
    public class HotelContext : IdentityDbContext<ApplicationUsers>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HotelContext(DbContextOptions<HotelContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<HotelFacilities> HotelFacilities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Facilitiy> Facilities { get; set; }
    }
}
