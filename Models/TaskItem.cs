using System.ComponentModel.DataAnnotations;

namespace team_project.Models
{
    // Task Model
    public class TaskItem
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string TaskName { get; set; } // Changed from Title to TaskName

        [Required]
        public string Description { get; set; }

        [Required]
        public string Priority { get; set; } // High, Medium, Low

        [Required]
        public DateTime DueDate { get; set; } // Changed from Deadline to DueDate
        
        [Required]
        public bool IsCompleted { get; set; }
    }
}