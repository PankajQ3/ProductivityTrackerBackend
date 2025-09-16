namespace ProductivityTrackerBackend.Models
{
    public class TimeLog
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DurationInMinutes { get; set; }

        // Foreign Key to Item
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}
