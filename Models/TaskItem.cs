namespace team_project.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string TaskName { get; set; } // Changed from Title to TaskName
        public string Description { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public DateTime DueDate { get; set; } // Changed from Deadline to DueDate
        public bool IsCompleted { get; set; }
    }
}