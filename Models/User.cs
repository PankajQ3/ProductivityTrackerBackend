namespace ProductivityTrackerBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Navigation Property: One User → Many Goals
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
