using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartTeacher.Data.Models;
using SmartTeacher.Data.Models.SeederTables;

namespace SmartTeacher.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<FormOfEducation> FormOfEducations { get; set; } = null!;
        public virtual DbSet<QualificationLevel> QualificationLevels { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TestPeriod> TestPeriods { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedQualificationLevels(builder);
            SeedFormOfEdcuation(builder);
        }

        private void SeedFormOfEdcuation(ModelBuilder builder)
        {
            builder.Entity<FormOfEducation>().HasData(
                new FormOfEducation { EductionForm = "Онлайн" },
                new FormOfEducation { EductionForm = "Присъствено" }
                );
        }
        private void SeedQualificationLevels(ModelBuilder builder)
        {
            builder.Entity<QualificationLevel>().HasData(
                new QualificationLevel { QualificationStage = "Начално", QualificationType = "Основен Първи Етап" },
                new QualificationLevel { QualificationStage = "Средно", QualificationType = "Основен Втори Етап" },
                new QualificationLevel { QualificationStage = "Средно", QualificationType = "Профилирани Гимназии (форма IX до XII - Професионално средно образование)" },
                new QualificationLevel { QualificationStage = "Средно", QualificationType = "Професионални гимназии и/или техникуми (Професионално средно образование)" },
                new QualificationLevel { QualificationStage = "Средно", QualificationType = "Професионални училища (Професионално средно образование)" },
                new QualificationLevel { QualificationStage = "Средно", QualificationType = "Средно образование" },
                new QualificationLevel { QualificationStage = "Висше", QualificationType = "Бакалавър" },
                new QualificationLevel { QualificationStage = "Висше", QualificationType = "Магистър" },
                new QualificationLevel { QualificationStage = "Висше", QualificationType = "Доктор" },
                new QualificationLevel { QualificationStage = "Висше", QualificationType = "Обучение на предучилищни и учители в началните класове" },
                new QualificationLevel { QualificationStage = "Висше", QualificationType = "Обучение на учители в средните училища" }
            );
        }
    }

}