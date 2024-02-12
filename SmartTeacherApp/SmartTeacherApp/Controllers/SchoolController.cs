using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTeacher.Services.Data.Interfaces;
using SmartTeacher.Web.ViewModels.School;
using System.Security.Claims;

namespace SmartTeacherApp.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService service;

        public SchoolController(ISchoolService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var schools = await service.AllAsync();

            return View(schools);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Search(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return RedirectToAction(nameof(Index));
            }
            var schools = await service.AllSearchedAsync(search);
            if (schools.Count() > 0)
            {
                return View("Index");
            }
            return View("Index", schools);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bool schoolExists = SchoolExists(id);
            if (!schoolExists)
            {
                return NotFound();
            }

            SchoolDetailsViewModel viewModel = await service.GetDetailsByIdAsync(id);
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSchoolViewModel bindingModel)
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

            var school = await service.GetSchoolAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            var viewModel = new EditSchoolViewModel
            {
                FullName = school.FullName,
                Address = school.Address,
                Teachers = school.Teachers
            };


            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id, EditSchoolViewModel bindingModel)
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

            var school = await service.GetSchoolAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            var viewModel = new DeleteSchoolViewModel
            {
                FullName = school.FullName,
                Address = school.Address,
                Teachers = school.Teachers
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

        public bool SchoolExists(string id)
        {
            return service.SchoolExists(id);
        }

    }
}
