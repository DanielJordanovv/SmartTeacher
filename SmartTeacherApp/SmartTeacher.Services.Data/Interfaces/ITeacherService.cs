namespace SmartTeacher.Services.Data.Interfaces
{
    public interface ITeacherService
    {
            bool EmailExistsAsync(string email);
    }
}
