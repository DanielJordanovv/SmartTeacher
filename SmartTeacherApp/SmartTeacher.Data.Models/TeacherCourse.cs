using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTeacher.Data.Models
{
    public class TeacherCourse
    {
        public TeacherCourse()
        {
            this.CourseId = Guid.NewGuid();
            this.TeacherId = Guid.NewGuid();
        }
        [Required]
        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } = null!;
        [Required]
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;
    }
}
