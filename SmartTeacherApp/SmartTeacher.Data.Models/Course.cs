using SmartTeacher.Data.Models.SeederTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartTeacher.Common.EntityValidationConstants.Course;

namespace SmartTeacher.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Id = Guid.NewGuid();
            this.TeacherCourses = new HashSet<TeacherCourse>();
            //this.TeacherCourseId = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Required]
        [StringLength(NameMaxLength,ErrorMessage =NameErrorMessage,MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(PlaceMaxLength, ErrorMessage = PlaceErrorMessage, MinimumLength = PlaceMinLenght)]
        public string Place { get; set; } = null!;
        [Required]
        [StringLength(PlaceMaxLength,ErrorMessage =EducationOrganisationErrorMessage,MinimumLength =EducationOrganisationMinLenght)]
        public string EducationOrganisiation { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [ForeignKey("FormOfEducation")]
        public int FormOfEducationId { get; set; }
        public virtual FormOfEducation FormOfEducation { get; set; } = null!;
        public int HoursOfEducation { get; set; }
        public int Credits { get; set; }
        //[Required]
        //[ForeignKey("TeacherCourse")]
        //public Guid TeacherCourseId { get; set; }
        //public virtual TeacherCourse TeacherCourse { get; set; } = null!;
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
