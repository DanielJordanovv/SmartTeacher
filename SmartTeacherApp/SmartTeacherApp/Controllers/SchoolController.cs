using Microsoft.AspNetCore.Mvc;

namespace SmartTeacherApp.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
