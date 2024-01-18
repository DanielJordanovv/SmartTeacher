using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string QualificationLevel { get; set; }
        //TODO
        public string Specification { get; set; } = null!;
        //
        public string DimplomaNumber { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
    }
}
