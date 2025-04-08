using System.ComponentModel.DataAnnotations;

namespace TaskTrackingSystem.Models
{
    public interface IPerson
    {
        int ID { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
