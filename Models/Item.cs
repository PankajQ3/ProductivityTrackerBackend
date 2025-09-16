namespace ProductivityTrackerBackend.Models
{
    public class Item
    {
        public int Id { get; set; }

        // Basic Details
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public bool Completed { get; set; }

        // Foreign Key to Goal
        public int GoalId { get; set; }
        public Goal Goal { get; set; } = null!;

        // ✅ Navigation Property: One Item → Many TimeLogs
        public ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();

        // Auditing
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
