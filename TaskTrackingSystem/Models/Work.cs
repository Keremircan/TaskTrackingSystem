using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTrackingSystem.Models
{
    public class Work
    {
        [Key]
        public int WorkID { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int StaffID { get; set; }
        [Required]
        public int IsRead { get; set; } = 0;
        [Required]
        public int IsCompleted { get; set; } = 0;
        public string? Comment { get; set; } = string.Empty;
    }
}
