using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTeacher.Services.Data.Interfaces;
using SmartTeacher.Web.ViewModels.Course;
using SmartTeacher.Web.ViewModels.School;

namespace SmartTeacherApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService service;
        
        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index(string schoolId)
        {
            var courses = await service.AllAsync(schoolId);
            courses = courses.OrderByDescending(x => x.StartDate).ToList();
            return View(courses);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Search(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return RedirectToAction(nameof(Index));
            }
            var courses = await service.AllSearchedAsync(search);
            if (courses.Count() > 0)
            {
                return View("Index");
            }
            return View("Index", courses);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bool schoolExists = CourseExists(id);
            if (!schoolExists)
            {
                return NotFound();
            }

            CourseDetailsViewModel viewModel = await service.GetDetailsByIdAsync(id);
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddCourseViewModel bindingModel)
        {

            if (!this.ModelState.IsValid)
            {

                return this.View(bindingModel);
            }
            try
            {
                await service.CreateAsync(bindingModel);
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Name", "Product already exists");
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new product! Please try again later !");

                return this.View(bindingModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var course = await service.GetCourseAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var viewModel = new EditCourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Place = course.Place,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                FormOfEducation = course.FormOfEducation,
                HoursOfEducation = course.HoursOfEducation,
                Credits = course.Credits
            };


            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id, EditCourseViewModel bindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(bindingModel);
                }
                try
                {
                    await service.UpdateAsync(id, bindingModel);
                    return this.RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Name", "Product already exists");
                    this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new product! Please try again later !");

                    return this.View(bindingModel);
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Product with the same name and description already exists!";
                return View();
            }
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await service.GetCourseAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var viewModel = new DeleteCourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Place = course.Place,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                FormOfEducation = course.FormOfEducation,
                HoursOfEducation = course.HoursOfEducation,
                Credits = course.Credits
            };

            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public bool CourseExists(string id)
        {
            return service.CourseExists(id);
        }
    }
}
