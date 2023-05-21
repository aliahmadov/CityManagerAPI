using CityManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityManagerApi.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities(int userId)
        {
            var cities = _context
                .Cities
                .Include(c=>c.Photos)
                 .Where(c=>c.UserId == userId)  
                .ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = _context
                .Cities
                .Include(c => c.Photos)
                .FirstOrDefault(c => c.Id == cityId);
            return city;
        }

        public Photo GetPhotoById(int photoId)
        {
            var photo=_context
                .Photos.FirstOrDefault(c => c.Id == photoId);
            return photo;
        }

        public List<Photo> GetPhotosByCityId(int cityId)
        {
            var photos = _context
                .Photos
                .Where(p => p.CityId == cityId)
                .ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
