using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Repositories.Interfaces;
using ProductivityTrackerBackend.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ProductivityTrackerBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        // Validate user credentials
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
                return null;

            // Validate password (assuming passwords are hashed)
            var hashedPassword = HashPassword(password);
            if (user.PasswordHash != hashedPassword)
                return null;

            return user;
        }

        // Get user by ID
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        // Hash password
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<User> RegisterUserAsync(string username, string email, string password)
        {
            // Check if the user already exists
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            // Hash the password
            var passwordHash = HashPassword(password);

            // Create and save the new user
            var newUser = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash
            };

            return await _userRepository.AddUserAsync(newUser);
        }

    }
}
