using Microsoft.EntityFrameworkCore;
namespace Lab_3.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Subject { get; set; } = "";

        public string AssignedClasses { get; set; } = "";

        public int teachingYears { get; set; } 

    }
}
