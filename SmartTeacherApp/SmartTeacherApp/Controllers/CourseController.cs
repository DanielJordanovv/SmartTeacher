using Microsoft.AspNetCore.Mvc;

namespace SmartTeacherApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
