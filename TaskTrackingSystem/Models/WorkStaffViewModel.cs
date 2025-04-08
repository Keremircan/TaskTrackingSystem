using System.ComponentModel.DataAnnotations;

namespace TaskTrackingSystem.Models
{
    public class WorkStaffViewModel
    {
        [Required]
        public Work Work { get; set; }
        [Required]
        public List<Staff> Staffs { get; set; }
    }
}
