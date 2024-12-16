using System.ComponentModel.DataAnnotations;

namespace team_project.Models
{
    // Account Model
    public class Account
    {
        
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }

}