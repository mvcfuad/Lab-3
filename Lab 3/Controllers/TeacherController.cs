using Lab_3.Models;
using Lab_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab_3.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public TeacherController(ApplicationDbContext context, IWebHostEnvironment environment)  
        {
            this.context = context;
            this.environment = environment;
        }

        // Updated Index action to include search functionality
        public IActionResult Index(string searchString)
        {
            // Fetch all teachers from the database
            var teachers = context.Teachers.AsQueryable();

            // Filter teachers if a search string is provided
            if (!string.IsNullOrEmpty(searchString))
            {
                // Filter by name (case-insensitive)
                teachers = teachers.Where(t => t.Name.Contains(searchString));
            }

            // Return the filtered or full list to the view
            var teacherList = teachers.OrderByDescending(t => t.Id).ToList();
            return View(teacherList);
        }




        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(TeacherDto teacherDto)
        {
            if (!ModelState.IsValid) {
                return View(teacherDto);
            }

            // Saves inputted information in database
            Teacher teacher = new Teacher()
            {
                Name = teacherDto.Name,
                Email = teacherDto.Email,
                Phone = teacherDto.Phone,
                Subject = teacherDto.Subject,
                AssignedClasses = teacherDto.AssignedClasses,
                teachingYears = teacherDto.teachingYears,
            };


            // Save the changes
            context.Teachers.Add(teacher);
            context.SaveChanges();




            return RedirectToAction("Index", "Teacher");
        }

        public IActionResult Edit(int id)
        {
            var teacher = context.Teachers.Find(id);

            if (teacher == null) {
                return RedirectToAction("Index", "Teacher");
            }


            // Create teacherDto from teacher
            var teacherDto = new TeacherDto()
            {
                Name = teacher.Name,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Subject = teacher.Subject,
                AssignedClasses = teacher.AssignedClasses,
                teachingYears = teacher.teachingYears,
            };


            ViewData["TeacherId"] = teacher.Id;

            return View(teacherDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, TeacherDto teacherDto)
        {
            var teacher = context.Teachers.Find(id);

            if (teacher == null)
            {
                return RedirectToAction("Index", "Teacher");
            }

            if (!ModelState.IsValid)
            {
                ViewData["TeacherId"] = teacher.Id;
                return View(teacherDto);
            }


            // Update the teacher in the database
            teacher.Name = teacherDto.Name;
            teacher.Email = teacherDto.Email;
            teacher.Phone = teacherDto.Phone;
            teacher.Subject = teacherDto.Subject;
            teacher.AssignedClasses = teacherDto.AssignedClasses;
            teacher.teachingYears = teacherDto.teachingYears;


            context.SaveChanges();

            return RedirectToAction("Index", "Teacher");
        }

     

        public IActionResult Delete(int id) 
        {
            var teacher = context.Teachers.Find(id);

            if (teacher == null)
            {
                return RedirectToAction("Index", "Teacher");
            }

            context.Teachers.Remove(teacher);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Teacher");

        }
    }
}
