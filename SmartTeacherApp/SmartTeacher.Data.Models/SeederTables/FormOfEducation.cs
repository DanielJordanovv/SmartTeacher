namespace SmartTeacher.Data.Models.SeederTables
{
    public class FormOfEducation
    {
        public FormOfEducation()
        {
            this.Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string EductionForm { get; set; } = null!;
        public virtual ICollection<Course>  Courses { get; set; }
    }
}
