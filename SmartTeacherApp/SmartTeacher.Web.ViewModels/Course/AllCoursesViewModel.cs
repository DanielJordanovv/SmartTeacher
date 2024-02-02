using SmartTeacher.Data.Models.SeederTables;
using SmartTeacher.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartTeacher.Web.ViewModels.Course
{
    public class AllCoursesViewModel
    {
        public AllCoursesViewModel()
        {
            this.Id = Guid.NewGuid();
            this.TeacherCourses = new List<string>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Place { get; set; } = null!;
        public string EducationOrganisiation { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int FormOfEducationId { get; set; }
        public string FormOfEducation { get; set; } = null!;
        public int HoursOfEducation { get; set; }
        public int Credits { get; set; }
        public virtual List<string> TeacherCourses { get; set; }
    }
}
