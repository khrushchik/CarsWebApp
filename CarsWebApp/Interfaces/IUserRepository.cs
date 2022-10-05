using CarsWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Create(User user);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByIdAsync(int id);
    }
}
