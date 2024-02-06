using Guards;
using Microsoft.EntityFrameworkCore;
using SmartTeacher.Data;
using SmartTeacher.Data.Models;
using SmartTeacher.Services.Data.Interfaces;
using SmartTeacher.Web.ViewModels.Course;
using SmartTeacher.Web.ViewModels.School;

namespace SmartTeacher.Services.Data
{
    public class SchoolService : ISchoolService
    {
        private readonly SmartTeacherDbContext context;
        public SchoolService(SmartTeacherDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AllSchoolsViewModel>> AllAsync()
        {
            return await context.Schools
                .Select(p => new AllSchoolsViewModel
                {
                    Id = p.Id,
                    Code = p.Code,
                    FullName = p.FullName,
                    Address = p.Address,
                    Teachers = p.Teachers
                }).ToListAsync();
        }

        public async Task<IEnumerable<AllSchoolsViewModel>> AllSearchedAsync(string search)
        {
            Guard.ArgumentNotNull(search, nameof(search));
            return await context.Schools.Where(x => x.FullName.ToLower().Contains(search.ToLower())).Select(p => new AllSchoolsViewModel
            {
                Id = p.Id,
                Code = p.Code,
                FullName = p.FullName,
                Address = p.Address,
                Teachers = p.Teachers
            }).ToListAsync();
        }

        public async Task CreateAsync(AddSchoolViewModel model)
        {
            Guard.ArgumentNotNull(model, nameof(model));
            var school = new School
            {
                Code = model.Code,
                FullName = model.FullName,
                Address = model.Address,
                Teachers = model.Teachers
            };
            if (context.Schools.Any(x => x. FullName == school.FullName))
            {
                throw new Exception();
            }
            else
            {
                await context.Schools.AddAsync(school);
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            var school = await context.Schools.FindAsync(id);
            Guard.ArgumentNotNull(school, nameof(school));
            await context.SaveChangesAsync();
        }

        public async Task<SchoolDetailsViewModel> GetDetailsByIdAsync(string id)
        {
             School school = await context
                 .Schools
                 .FirstAsync(p => p.Id.ToString() == id);


            SchoolDetailsViewModel model = new SchoolDetailsViewModel
            {
                Id = school.Id,
                Code = school.Code,
                FullName = school.FullName,
                Address = school.Address,
                Teachers = school.Teachers
            };
            return model;
        }

        public async Task<School> GetSchoolAsync(string id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            School? product = await context.Schools.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return product;
        }

        public bool SchoolExists(string id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            return context.Schools.Any(e => e.Id.ToString() == id);
        }

        public async Task UpdateAsync(string id, EditSchoolViewModel model)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            Guard.ArgumentNotNull(model, nameof(model));
            var schoolToUpdate = await context.Schools.FindAsync(id);

            Guard.ArgumentNotNull(schoolToUpdate, nameof(schoolToUpdate));
            schoolToUpdate.FullName = model.FullName;
            schoolToUpdate.Address = model.Address;
            schoolToUpdate.Teachers = model.Teachers;
            if (context.Schools.Any(x => x.FullName == schoolToUpdate.FullName && x.Address == schoolToUpdate.Address))
            {
                throw new Exception();
            }
            await context.SaveChangesAsync();
        }
    }
}
