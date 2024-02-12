using System.ComponentModel.DataAnnotations;
using static SmartTeacher.Common.EntityValidationConstants.Teacher;

namespace SmartTeacher.Web.ViewModels.Teacher
{
    public class RegisterFormModel
    {
        public Guid UserId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(15, MinimumLength = 1,
            ErrorMessage = "Юзвърнеймът трябва да бъде между 1 и 15 символа дълъг.")]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = "Паролата трябва да бъде между 5 и 20 символа дълга.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLenght)]
        [Display(Name ="Малко име")]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = MiddleNameMinLenght)]
        [Display(Name = "Перзиме")]
        public string MiddleName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLenght)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
