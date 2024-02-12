using SmartTeacher.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SmartTeacher.Common.EntityValidationConstants.School;


namespace SmartTeacher.Web.ViewModels.School
{
    public class DeleteSchoolViewModel
    {
        public DeleteSchoolViewModel()
        {
            this.Teachers = new HashSet<Data.Models.Teacher>();
        }
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        public Guid Code { get; set; }
        [Required]
        [StringLength(FullNameMaxLength, ErrorMessage = FullNameErrorMessage, MinimumLength = FullNameMinLenght)]
        public string FullName { get; set; } = null!;
        [Required]
        [StringLength(AddressNumberMaxLength, ErrorMessage = FullNameErrorMessage, MinimumLength = FullNameMinLenght)]
        public string Address { get; set; } = null!;
        public virtual ICollection<Data.Models.Teacher> Teachers { get; set; }
    }
}
