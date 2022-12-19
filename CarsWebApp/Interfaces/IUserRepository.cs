using CarsWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateAsync(User user);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> AddUserNameAsync(int id, User user);
    }
}
