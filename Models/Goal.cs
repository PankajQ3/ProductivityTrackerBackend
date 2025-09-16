namespace ProductivityTrackerBackend.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TargetValue { get; set; }
        public int ProgressValue { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Navigation Property: One Goal → Many Items
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
