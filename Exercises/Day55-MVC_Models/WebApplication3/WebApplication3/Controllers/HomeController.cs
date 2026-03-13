using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Rahul Sharma", Position = "Software Developer", Salary = 55000 },
                new Employee { Id = 2, Name = "Amit Verma", Position = "QA Engineer", Salary = 42000 },
                new Employee { Id = 3, Name = "Sneha Gupta", Position = "HR Manager", Salary = 50000 },
                new Employee { Id = 4, Name = "Priya Singh", Position = "UI/UX Designer", Salary = 47000 }
            };

            ViewBag.Announcement = "Company meeting today at 4:00 PM in Conference Hall.";
            ViewData["Department"] = "IT Department";
            ViewData["IsActive"] = true;

            return View(employees);
        }
    }
}