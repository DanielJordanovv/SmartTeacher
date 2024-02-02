using SmartTeacher.Data.Models;
using SmartTeacher.Web.ViewModels.School;

namespace SmartTeacher.Services.Data.Interfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<AllSchoolsViewModel>> AllAsync();
        Task<IEnumerable<AllSchoolsViewModel>> AllSearchedAsync(string search);
        Task<SchoolDetailsViewModel> GetDetailsByIdAsync(string id);
        Task CreateAsync(AddSchoolViewModel model);
        Task UpdateAsync(string id, EditSchoolViewModel model);
        Task DeleteAsync(string id);
        Task<School> GetSchoolAsync(string id);
        bool SchoolExists(string id);
    }
}
