using Guards;
using SmartTeacher.Data;
using SmartTeacher.Services.Data.Interfaces;

namespace SmartTeacher.Services.Data
{
    public class TeacherService :  ITeacherService
    {
        private readonly SmartTeacherDbContext context;
        public TeacherService(SmartTeacherDbContext contex)
        {
            this.context = contex;
        }
        public bool EmailExistsAsync(string email)
        {
            Guard.ArgumentNotNull(email, nameof(email));
            return context.Teachers.Any(x => x.Email == email);
        }
    }
}
