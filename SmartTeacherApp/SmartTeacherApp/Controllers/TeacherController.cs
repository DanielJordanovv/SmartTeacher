using Microsoft.AspNetCore.Mvc;

namespace SmartTeacherApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
