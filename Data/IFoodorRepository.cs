using System.Collections.Generic;
using System.Threading.Tasks;
using Fooder.API.Models;

namespace Fooder.API.Data
{
    public interface IFoodorRepository
    {
         void Add<T>(T entity) where T: class;
         
         void Delete<T>(T entity) where T: class;

         Task<bool> SaveAll();

         Task<IEnumerable<Restaurant>> GetRestaurants();

         Task<User> GetUser(int id);
         
         Task<Photo> GetPhoto(int id);

         Task<Restaurant> GetRestaurant(int id);
         
    }
}