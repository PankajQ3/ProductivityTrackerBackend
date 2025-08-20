using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> RegisterUserAsync(string username, string email, string password);
    }
}
