using System.ComponentModel.DataAnnotations;

namespace SmartTeacher.Data.Models
{
    public class Courses
    {
        public Courses()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Place { get; set; } = null!;
        public string EducationOrganisiation { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FormOfEducation { get; set; } = null!;
        public int HoursOfEducation { get; set; }
        public int Credits { get; set; }
    }
}
