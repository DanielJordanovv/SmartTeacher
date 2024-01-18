using System.ComponentModel.DataAnnotations;

namespace SmartTeacher.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid();
        }
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(15,ErrorMessage="First name should be between 3 and 15",MinimumLength =3)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "Middle name should be between 5 and 15", MinimumLength = 5)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "Last name should be between 5 and 15", MinimumLength = 5)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Incorect email.")]
        public string EmailAddress { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        [Required]
        public BirthPlace BirthPlace { get; set; } 
        [Required]
        public Position Position { get; set; }
        [Required]
        public Subject Subject { get; set; }


    }
}
