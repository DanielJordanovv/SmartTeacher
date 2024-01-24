namespace SmartTeacher.Data.Models.SeederTables
{
    public class QualificationLevel
    {
        public int Id { get; set; }
        public string QualificationStage { get; set; } = null!;
        public string QualificationType { get; set; } = null!;
    }
}
