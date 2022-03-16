using AhoyHotelManagement.CommonUtils;
using AhoyHotelManagement.DAL.Domain;
using AhoyHotelManagement.DAL.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AhoyHotelManagement.DAL.Presistence.Repositories
{
    #region Interface
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        Task<Hotel> GetHotelDetails(Guid id);
        Task<List<Hotel>> GetHotelsByRating(string rating);
        Task<List<Hotel>> GetHotelsByName(string name);
        Task<List<Hotel>> GetHotelsByLocation(string location);
    }
    #endregion
    #region Implementation
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelContext context)
           : base(context)
        {

        }
        public async Task<Hotel> GetHotelDetails(Guid id)
        {
            var result = await this.GetMany(x => x.Id == id)
                           .Include("Images")
                           .Include("Rooms")
                           .Include("Facilities.Facilitiy")
                           .FirstOrDefaultAsync();
            return result;
        }
        public async Task<List<Hotel>> GetHotelsByRating(string rating)
        {
            var result = await this.GetMany(x => x.Rating == rating)
                           .Include("Images")
                           .Include("Rooms")
                           .Include("Facilities.Facilitiy")
                           .ToListAsync();
            return result;
        }
        public async Task<List<Hotel>> GetHotelsByName(string name)
        {
            var result = await this.GetMany(x => x.Name == name)
                           .Include("Images")
                           .Include("Rooms")
                           .Include("Facilities.Facilitiy")
                           .ToListAsync();
            return result;
        }
        public async Task<List<Hotel>> GetHotelsByLocation(string location)
        {
            var result = await this.GetMany(x => x.Location == location)
                           .Include("Images")
                           .Include("Rooms")
                           .Include("Facilities.Facilitiy")
                           .ToListAsync();
            return result;
        }
    }
    #endregion
}
