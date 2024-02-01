namespace SmartTeacher.Data.Models.SeederTables
{
    public class QualificationLevel
    {
        public QualificationLevel()
        {
            this.Diplomas = new HashSet<Diploma>();
        }
        public int Id { get; set; }
        public string QualificationStage { get; set; } = null!;
        public string QualificationType { get; set; } = null!;
        public virtual ICollection<Diploma> Diplomas { get; set; }
    }
}
