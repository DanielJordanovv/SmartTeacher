using SmartTeacher.Data.Models.SeederTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartTeacher.Common.EntityValidationConstants.Diploma;

namespace SmartTeacher.Data.Models
{
    public class Diploma
    {
        public Diploma()
        {
            this.Id = Guid.NewGuid();
            this.TeacherId = Guid.NewGuid();
        }
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(InstitutionMaxLength,ErrorMessage=InstitutionErrorMessage,MinimumLength =InstitutionMinLenght)]
        public string Institution { get; set; } = null!;
        [ForeignKey("QualificationLevel")]
        public int QualificationLevelId { get; set; }
        public virtual QualificationLevel QualificationLevel { get; set; } = null!;
        [Required]
        [StringLength(SpecificationMaxLength, ErrorMessage = SpecificationErrorMessage, MinimumLength = SpecificationMinLenght)]
        public string Specification { get; set; } = null!;
        [Required]
        [StringLength(DiplomaNumberMaxLength, ErrorMessage = DiplomaNumberErrorMessage, MinimumLength = DiplomaNumberMinLenght)]
        public string DimplomaNumber { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }=null!; 
    }
}
