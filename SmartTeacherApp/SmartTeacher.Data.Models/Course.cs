using SmartTeacher.Data.Models.SeederTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTeacher.Data.Models
{
    public class Course
    {
        public Course()
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
        [Required]
        [ForeignKey("FormOfEducation")]
        public int FormOfEducationId { get; set; }
        public virtual FormOfEducation FormOfEducation { get; set; } = null!;
        public int HoursOfEducation { get; set; }
        public int Credits { get; set; }
    }
}
