using SmartTeacher.Data.Models.SeederTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTeacher.Data.Models
{
    public class Diploma
    {
        public Diploma()
        {
            this.Id = Guid.NewGuid();
        }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Institution { get; set; } = null!;
        [ForeignKey("QualificationLevel")]
        public int QualificationLevelId { get; set; }
        public virtual QualificationLevel QualificationLevel { get; set; } = null!;
        public string Specification { get; set; } = null!;
        public string DimplomaNumber { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
    }
}
