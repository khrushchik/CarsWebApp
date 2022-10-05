using CarsWebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDomain>> GetUsersASync();
        Task<UserCreateDomain> CreateUserAsync(UserCreateDomain userCreateDomain);
        Task<UserDomain> GetUserByEmailAsync(string email);
        Task<UserDomain> GetUserByIdAsync(int id);

    }
}
