namespace team_project.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public DateTime Deadline { get; set; }
        public string Category { get; set; }
        public bool IsCompleted { get; set; }
    }
}