using SmartTeacher.Data.Models;
using SmartTeacher.Web.ViewModels.Course;

namespace SmartTeacher.Services.Data.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<AllCoursesViewModel>> AllAsync(string schoolId);
        Task<IEnumerable<AllCoursesViewModel>> AllSearchedAsync(string search);
        Task<CourseDetailsViewModel> GetDetailsByIdAsync(string id);
        Task CreateAsync(AddCourseViewModel model);
        Task UpdateAsync(string id, EditCourseViewModel model);
        Task DeleteAsync(string id);
        Task<Course> GetCourseAsync(string id);
        bool CourseExists(string id);
    }
}
