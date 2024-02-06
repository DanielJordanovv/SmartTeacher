using SmartTeacher.Data.Models;

namespace SmartTeacher.Web.ViewModels.School
{
    public class AllSchoolsViewModel
    {
        public AllSchoolsViewModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Code = Guid.NewGuid();
            this.Teachers = new List<Data.Models.Teacher>();
        }
        public string Id { get; set; } = null!;
        public Guid Code { get; set; }
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public virtual ICollection<Data.Models.Teacher> Teachers { get; set; }

    }
}
