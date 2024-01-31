using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartTeacher.Data.Models
{
    public class Teacher:IdentityUser<Guid>
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid();
        }
        [Required]
        [StringLength(15,ErrorMessage="First name should be between 3 and 15",MinimumLength =3)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "Middle name should be between 5 and 15", MinimumLength = 5)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "Last name should be between 5 and 15", MinimumLength = 5)]
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public string Position { get; set; } = null!;
        [Required]
        public  string Subject { get; set; } = null!;
    }
}
