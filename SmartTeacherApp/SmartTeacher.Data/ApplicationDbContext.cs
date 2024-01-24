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
        public virtual DbSet<BirthPlace> BirthPlaces { get; set; } = null!;
        public virtual DbSet<FormOfEducation> FormOfEducations { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<QualificationLevel> QualificationLevels { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TestPeriod> TestPeriods { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedQualificationLevels(builder);
            SeedFormOfEdcuation(builder);
            SeedBirhPlaces(builder);
        }
        private void SeedBirhPlaces(ModelBuilder builder)
        {
            builder.Entity<BirthPlace>().HasData(
    new BirthPlace { Region = "Айтос" },
    new BirthPlace { Region = "Асеновград" },
    new BirthPlace { Region = "Ахтопол" },
    new BirthPlace { Region = "Балчик" },
    new BirthPlace { Region = "Банкя" },
    new BirthPlace { Region = "Банско" },
    new BirthPlace { Region = "Батак" },
    new BirthPlace { Region = "Белене" },
    new BirthPlace { Region = "Белица" },
    new BirthPlace { Region = "Белослав" },
    new BirthPlace { Region = "Берковица" },
    new BirthPlace { Region = "Битоля" },
    new BirthPlace { Region = "Благоевград" },
    new BirthPlace { Region = "Ботевград" },
    new BirthPlace { Region = "Брацигово" },
    new BirthPlace { Region = "Брезник" },
    new BirthPlace { Region = "Бургас" },
    new BirthPlace { Region = "Бяла" },
    new BirthPlace { Region = "Варна" },
    new BirthPlace { Region = "Велес" },
    new BirthPlace { Region = "Велики Преслав" },
    new BirthPlace { Region = "Велико Търново" },
    new BirthPlace { Region = "Велинград" },
    new BirthPlace { Region = "Видин" },
    new BirthPlace { Region = "Враца" },
    new BirthPlace { Region = "Вършец" },
    new BirthPlace { Region = "Габрово" },
    new BirthPlace { Region = "Гевгели" },
    new BirthPlace { Region = "Горна Оряховица" },
    new BirthPlace { Region = "Гоце Делчев" },
    new BirthPlace { Region = "Гюмюрджина" },
    new BirthPlace { Region = "Дедеагач" },
    new BirthPlace { Region = "Демир Хисар" },
    new BirthPlace { Region = "Димитровград" },
    new BirthPlace { Region = "Добрич" },
    new BirthPlace { Region = "Дойран" },
    new BirthPlace { Region = "Долна Баня" },
    new BirthPlace { Region = "Долна Оряховица" },
    new BirthPlace { Region = "Долни Дъбник" },
    new BirthPlace { Region = "Драма" },
    new BirthPlace { Region = "Дупница" },
    new BirthPlace { Region = "Елена" },
    new BirthPlace { Region = "Исперих" },
    new BirthPlace { Region = "Ихтиман" },
    new BirthPlace { Region = "Кавала" },
    new BirthPlace { Region = "Каварна" },
    new BirthPlace { Region = "Казанлък" },
    new BirthPlace { Region = "Калофер" },
    new BirthPlace { Region = "Карлово" },
    new BirthPlace { Region = "Карнобат" },
    new BirthPlace { Region = "Кешан" },
    new BirthPlace { Region = "Китен" },
    new BirthPlace { Region = "Козлодуй" },
    new BirthPlace { Region = "Копривщица" },
    new BirthPlace { Region = "Костенец" },
    new BirthPlace { Region = "Костур" },
    new BirthPlace { Region = "Котел" },
    new BirthPlace { Region = "Кресна" },
    new BirthPlace { Region = "Крушево" },
    new BirthPlace { Region = "Ксанти" },
    new BirthPlace { Region = "Кукуш" },
    new BirthPlace { Region = "Кърджали" },
    new BirthPlace { Region = "Кюстендил" },
    new BirthPlace { Region = "Лерин" },
    new BirthPlace { Region = "Ловеч" },
    new BirthPlace { Region = "Лозенград" },
    new BirthPlace { Region = "Лом" },
    new BirthPlace { Region = "Люле Бургас" },
    new BirthPlace { Region = "Мадан" },
    new BirthPlace { Region = "Мелник" },
    new BirthPlace { Region = "Момчилград" },
    new BirthPlace { Region = "Монтана" },
    new BirthPlace { Region = "Несебър" },
    new BirthPlace { Region = "Никопол" },
    new BirthPlace { Region = "Ниш" },
    new BirthPlace { Region = "Нова Загора" },
    new BirthPlace { Region = "Обзор" },
    new BirthPlace { Region = "Одрин" },
    new BirthPlace { Region = "Оряхово" },
    new BirthPlace { Region = "Охрид" },
    new BirthPlace { Region = "Павликени" },
    new BirthPlace { Region = "Пазарджик" },
    new BirthPlace { Region = "Панагюрище" },
    new BirthPlace { Region = "Перник" },
    new BirthPlace { Region = "Перущица" },
    new BirthPlace { Region = "Петрич" },
    new BirthPlace { Region = "Пещера" },
    new BirthPlace { Region = "Пирдоп" },
    new BirthPlace { Region = "Плевен" },
    new BirthPlace { Region = "Пловдив" },
    new BirthPlace { Region = "Поморие" },
    new BirthPlace { Region = "Попово" },
    new BirthPlace { Region = "Пордим" },
    new BirthPlace { Region = "Правец" },
    new BirthPlace { Region = "Прилеп" },
    new BirthPlace { Region = "Приморско" },
    new BirthPlace { Region = "Провадия" },
    new BirthPlace { Region = "Първомай" },
    new BirthPlace { Region = "Радомир" },
    new BirthPlace { Region = "Разград" },
    new BirthPlace { Region = "Разлог" },
    new BirthPlace { Region = "Русе" },
    new BirthPlace { Region = "Самоков" },
    new BirthPlace { Region = "Сандански" },
    new BirthPlace { Region = "Свиленград" },
    new BirthPlace { Region = "Свищов" },
    new BirthPlace { Region = "Своге" },
    new BirthPlace { Region = "Севлиево" },
    new BirthPlace { Region = "Серес" },
    new BirthPlace { Region = "Силистра" },
    new BirthPlace { Region = "Симеоновград" }
    new BirthPlace { Region = "Скопие" },
    new BirthPlace { Region = "Сливен" },
    new BirthPlace { Region = "Смолян" },
    new BirthPlace { Region = "Созопол" },
    new BirthPlace { Region = "Солун" },
    new BirthPlace { Region = "Сопот" },
    new BirthPlace { Region = "София" },
    new BirthPlace { Region = "Стара Загора" },
    new BirthPlace { Region = "Стражица" },
    new BirthPlace { Region = "Струга" },
    new BirthPlace { Region = "Струмица" },
    new BirthPlace { Region = "Тетово" },
    new BirthPlace { Region = "Тополовград" },
    new BirthPlace { Region = "Троян" },
    new BirthPlace { Region = "Трън" },
    new BirthPlace { Region = "Тулча" },
    new BirthPlace { Region = "Тутракан" },
    new BirthPlace { Region = "Търговище" },
    new BirthPlace { Region = "Харманли" },
    new BirthPlace { Region = "Хасково" },
    new BirthPlace { Region = "Хисар" },
    new BirthPlace { Region = "Царево" },
    new BirthPlace { Region = "Цариброд" },
    new BirthPlace { Region = "Цариград" },
    new BirthPlace { Region = "Чаталджа" },
    new BirthPlace { Region = "Чепеларе" },
    new BirthPlace { Region = "Червен бряг" },
    new BirthPlace { Region = "Чирпан" },
    new BirthPlace { Region = "Чорлу" },
    new BirthPlace { Region = "Шумен" },
    new BirthPlace { Region = "Щип" },
    new BirthPlace { Region = "Якоруда" },
    new BirthPlace { Region = "Ямбол" }
              );
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
        private void SeedPositions(ModelBuilder builder)
        {
            builder.Entity<Position>().HasData(
                new Position { PositionName = "Заместник-директор" },
                new Position { PositionName = "Учител" },
                new Position { PositionName = "Педагогически съветник" },
                new Position { PositionName = "Психолог" },
                new Position { PositionName = "Логопед" },
                new Position { PositionName = "Библиотекар" },
                new Position { PositionName = "Секретар" },
                new Position { PositionName = "Старши учител" },
                new Position { PositionName = "Други" }
            );
        }
    }

}