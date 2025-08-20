namespace ProductivityTrackerBackend.Models
{
    public class Item
    {
        public int Id { get; set; }

        // Basic Details
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Deadline { get; set; }
        public bool Completed { get; set; }



        // Foreign Key to Goal
        public int GoalId { get; set; } // Nullable, since an Item might not belong to a Goal
        public Goal Goal { get; set; }

        // Timestamp for Auditing
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
