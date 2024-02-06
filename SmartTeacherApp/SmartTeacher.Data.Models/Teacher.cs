using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartTeacher.Common.EntityValidationConstants.Teacher;

namespace SmartTeacher.Data.Models
{
    public class Teacher : IdentityUser<Guid>
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid();
            this.TestPeriods = new HashSet<TestPeriod>();
            this.Diplomas = new HashSet<Diploma>();
            this.TeacherCourses = new HashSet<TeacherCourse>();
            //this.TeacherCourseId = Guid.NewGuid();
        }
        [Required]
        [StringLength(FirstNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = FirstNameMinLenght)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(MiddleNameMaxLength, ErrorMessage = MiddleNameErrorMessage, MinimumLength = MiddleNameMinLenght)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [StringLength(LastNameMaxLength, ErrorMessage = LastNameErrorMessage, MinimumLength = LastNameMinLenght)]
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(BirthplaceMaxLength, ErrorMessage = BirthplaceErrorMessage, MinimumLength = BirthplaceMinLenght)]
        public string BirthPlace { get; set; } = null!;
        [Required]
        [StringLength(PossitionMaxLength, ErrorMessage = PossitionErrorMessage, MinimumLength = PossitionMinLenght)]
        public string Position { get; set; } = null!;
        [Required]
        [StringLength(SubjectMaxLength, ErrorMessage = SubjectErrorMessage, MinimumLength = SubjectMinLenght)]
        public string Subject { get; set; } = null!;
        [Required]
        [ForeignKey("School")]
        public string SchoolId { get; set; } = null!;
        public virtual School School { get; set; } = null!;
        [Required]
        [ForeignKey("Request")]
        public string RequestId { get; set; } = null!;
        public virtual Request Request { get; set; } = null!;
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
        public virtual ICollection<TestPeriod> TestPeriods { get; set; }
        public virtual ICollection<Diploma> Diplomas { get; set; }

    }
}
