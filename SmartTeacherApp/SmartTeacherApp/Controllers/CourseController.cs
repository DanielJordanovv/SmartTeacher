using Microsoft.AspNetCore.Mvc;
using SmartTeacher.Services.Data.Interfaces;

namespace SmartTeacherApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService service;
        
        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
