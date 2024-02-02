using Microsoft.AspNetCore.Mvc;
using SmartTeacher.Services.Data.Interfaces;

namespace SmartTeacherApp.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService service;

        public SchoolController(ISchoolService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
