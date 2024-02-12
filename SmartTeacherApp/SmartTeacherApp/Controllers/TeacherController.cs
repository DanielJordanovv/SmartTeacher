using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartTeacher.Data.Models;
using SmartTeacher.Services.Data.Interfaces;
using SmartTeacher.Web.ViewModels.Teacher;

namespace SmartTeacherApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SignInManager<Teacher> signInManager;
        private readonly UserManager<Teacher> userManager;
        private readonly ITeacherService userService;

        public TeacherController(SignInManager<Teacher> signInManager,
                              UserManager<Teacher> userManager, ITeacherService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateRecaptcha(Action = nameof(Register),
        //    ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (EmailExists(model.Email))
            {
                ModelState.AddModelError("Email", "Потребител с този имейл съществува");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Teacher user = new Teacher()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                BirthDate = model.BirthDate
            };

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.UserName);

            IdentityResult result =
                await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                //TempData[ErrorMessage] = "There was an error while attempting to login!. Try again later!";
                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
        public bool EmailExists(string email)
        {
            return userService.EmailExistsAsync(email);
        }
    }
}
