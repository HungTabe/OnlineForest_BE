using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineForestAPI.Data;
using OnlineForestAPI.DTO;
using OnlineForestAPI.Interfaces;
using OnlineForestAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineForestAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ForestOnlineDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ForestOnlineDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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
                Role = "USER",
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now,
                TotalTokenEarn = 0
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<LoginResponseDTO> LoginAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                throw new InvalidOperationException("Email or password incorrectly.");
            }

            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();

            var token = GenerateToken(user.Username, user.Role, user.Email);

            var LoginResponse = new LoginResponseDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Token = token,
                Role = user.Role
            };

            return LoginResponse;
        }

        public string GenerateToken(string username, string role, string email)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Email, email),

        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
