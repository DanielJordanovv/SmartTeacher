using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartTeacher.Data.Models;
using SmartTeacher.Data.Models.SeederTables;
using System.Reflection.Emit;

namespace SmartTeacher.Data
{
    public class SmartTeacherDbContext : IdentityDbContext
    {
        public SmartTeacherDbContext(DbContextOptions<SmartTeacherDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<FormOfEducation> FormOfEducations { get; set; } = null!;
        public virtual DbSet<QualificationLevel> QualificationLevels { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TestPeriod> TestPeriods { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeacherCourse>().HasKey(k => new { k.TeacherId, k.CourseId });
            builder.Entity<Teacher>()
                .HasOne(t => t.Request)
                .WithMany()
                .HasForeignKey(t => t.RequestId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
            SeedQualificationLevels(builder);
            SeedFormOfEdcuation(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        private void SeedFormOfEdcuation(ModelBuilder builder)
        {
            builder.Entity<FormOfEducation>().HasData(
                new FormOfEducation { Id = 1, EductionForm = "Присъствено" },
                new FormOfEducation { Id = 2, EductionForm = "Онлайн" }
                );
        }
        private void SeedQualificationLevels(ModelBuilder builder)
        {
            builder.Entity<QualificationLevel>().HasData(
                new QualificationLevel { Id = 11, QualificationStage = "Начално", QualificationType = "Основен Първи Етап" },
                new QualificationLevel { Id = 1, QualificationStage = "Средно", QualificationType = "Основен Втори Етап" },
                new QualificationLevel { Id = 2, QualificationStage = "Средно", QualificationType = "Профилирани Гимназии (форма IX до XII - Професионално средно образование)" },
                new QualificationLevel { Id = 3, QualificationStage = "Средно", QualificationType = "Професионални гимназии и/или техникуми (Професионално средно образование)" },
                new QualificationLevel { Id = 4, QualificationStage = "Средно", QualificationType = "Професионални училища (Професионално средно образование)" },
                new QualificationLevel { Id = 5, QualificationStage = "Средно", QualificationType = "Средно образование" },
                new QualificationLevel { Id = 6, QualificationStage = "Висше", QualificationType = "Бакалавър" },
                new QualificationLevel { Id = 7, QualificationStage = "Висше", QualificationType = "Магистър" },
                new QualificationLevel { Id = 8, QualificationStage = "Висше", QualificationType = "Доктор" },
                new QualificationLevel { Id = 9, QualificationStage = "Висше", QualificationType = "Обучение на предучилищни и учители в началните класове" },
                new QualificationLevel { Id = 10, QualificationStage = "Висше", QualificationType = "Обучение на учители в средните училища" }
            );
        }
    }

}