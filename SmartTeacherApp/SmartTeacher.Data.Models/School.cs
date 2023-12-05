using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTeacher.Data.Models
{
    public class School
    {
        public School()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Code = Guid.NewGuid();
        }
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        public Guid Code { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "The name should be between 10 and 60", MinimumLength = 10)]
        public string FullName { get; set; } = null!;
        [Required]
        [StringLength(40, ErrorMessage = "The address should be between 5 and 40", MinimumLength = 5)]
        public string Address { get; set; } = null!;
    }
}
