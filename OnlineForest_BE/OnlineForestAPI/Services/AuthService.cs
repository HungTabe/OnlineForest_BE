using Microsoft.EntityFrameworkCore;
using OnlineForestAPI.Data;
using OnlineForestAPI.Interfaces;
using OnlineForestAPI.Models;

namespace OnlineForestAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ForestOnlineDbContext _context;

        public AuthService(ForestOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(string username, string password, string email)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username || u.Email == email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username or email existed.");
            }

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now,
                TotalTokenEarn = 0
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                throw new InvalidOperationException("Username or password incorrectly.");
            }

            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
