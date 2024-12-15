using System.ComponentModel.DataAnnotations;
namespace Lab_3.Models
{
    public class TeacherDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        [Required]
        public string Subject { get; set; } = "";

        [Required]
        public string AssignedClasses { get; set; } = "";

        [Required]
        public int teachingYears { get; set; }
    }
}
