namespace ProductivityTrackerBackend.Models
{
    public class TimeLog
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DurationInMinutes { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }

}
