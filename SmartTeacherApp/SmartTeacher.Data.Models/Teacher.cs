using Microsoft.AspNetCore.Identity;
using SmartTeacher.Data.Models.SeederTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTeacher.Data.Models
{
    public class Teacher:IdentityUser<Guid>
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid();
        }
        [Required]
        [StringLength(15,ErrorMessage="First name should be between 3 and 15",MinimumLength =3)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "Middle name should be between 5 and 15", MinimumLength = 5)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [StringLength(15, ErrorMessage = "Last name should be between 5 and 15", MinimumLength = 5)]
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        [Required]
        [ForeignKey("BirthPlace")]
        public int BirthPlaceId { get; set; }
        public virtual BirthPlace BirthPlace { get; set; } = null!;
        [Required]
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; } = null!;
        [Required]
        public  string Subject { get; set; } = null!;
    }
}
