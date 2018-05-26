using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fooder.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fooder.API.Data
{
    public class FoodorRepository : IFoodorRepository
    {
        private readonly DataContext _context;

        public FoodorRepository(DataContext context)
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

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = await _context.Restaurants.Include(p => p.Photos).OrderByDescending(r => r.Created).ToListAsync();

            return restaurants;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}