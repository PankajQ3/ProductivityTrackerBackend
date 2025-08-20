using ProductivityTrackerBackend.Data;
using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, ApplicationDbContext>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username); // Get user by username
        Task<User> AddUserAsync(User user);
    }
}
