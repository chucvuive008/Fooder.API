using System.Threading.Tasks;
using Fooder.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fooder.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExist(string username);
    }
}