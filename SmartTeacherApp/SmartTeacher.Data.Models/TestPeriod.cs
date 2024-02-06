using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTeacher.Data.Models
{
    public class TestPeriod
    {
        public TestPeriod()
        {
            this.TeacherId = Guid.NewGuid();
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        [ForeignKey(nameof(Teacher))]
        public Guid TeacherId { get; set; } 
        public Teacher Teacher { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
