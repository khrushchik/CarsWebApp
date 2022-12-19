using AutoMapper;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarContext _context;
        private readonly IMapper _mapper;
        public UserRepository(CarContext carContext, IMapper mapper)
        {
            _context = carContext;
            _mapper = mapper;
        }
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(i=>i.Email==email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<User> AddUserNameAsync(int id, User user)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (userEntity is null)
                throw new KeyNotFoundException("User isn`t found");
            userEntity.UserName = user.UserName;
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }
    }
}
