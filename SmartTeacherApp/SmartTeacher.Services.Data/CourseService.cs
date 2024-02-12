using Guards;
using Microsoft.EntityFrameworkCore;
using SmartTeacher.Data;
using SmartTeacher.Data.Models;
using SmartTeacher.Services.Data.Interfaces;
using SmartTeacher.Web.ViewModels.Course;
using System;

namespace SmartTeacher.Services.Data
{
    public class CourseService : ICourseService
    {
        private readonly SmartTeacherDbContext context;
        public CourseService(SmartTeacherDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(AddCourseViewModel model)
        {
            Guard.ArgumentNotNull(model, nameof(model));
            var course = new Course
            {
                Name = model.Name,
                Place = model.Place,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                FormOfEducationId = model.FormOfEducationId,
                HoursOfEducation = model.HoursOfEducation,
                Credits = model.Credits
            };
            if (context.Courses.Any(x => x.Name == course.Name))
            {
                throw new Exception();
            }
            else
            {
                await context.Courses.AddAsync(course);
            }
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCoursesViewModel>> AllAsync(string schoolId)
        {
            return await context.Courses.Where(x => x.StartDate.Date < DateTime.Now && x.SchoolId == schoolId)
                .Select(p => new AllCoursesViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Place = p.Place,
                    StartDate = p.StartDate.ToString(),
                    EndDate = p.EndDate.ToString(),
                    FormOfEducation = p.FormOfEducation.EductionForm,
                    HoursOfEducation = p.HoursOfEducation,
                    Credits = p.Credits
                }).ToListAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            var course = await context.Courses.FindAsync(id);
            Guard.ArgumentNotNull(course, nameof(course));
            await context.SaveChangesAsync();
        }

        public async Task<Course> GetCourseAsync(string id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            Course? product = await context.Courses.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return product;
        }

        public bool CourseExists(string id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            return context.Courses.Any(e => e.Id.ToString() == id);
        }

        public async Task UpdateAsync(string id, EditCourseViewModel model)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            Guard.ArgumentNotNull(model, nameof(model));
            var courseToUpdate = await context.Courses.FindAsync(id);

            Guard.ArgumentNotNull(courseToUpdate, nameof(courseToUpdate));
            courseToUpdate.Name = model.Name;
            courseToUpdate.Place = model.Place;
            courseToUpdate.StartDate = model.StartDate;
            courseToUpdate.EndDate = model.EndDate;
            courseToUpdate.FormOfEducationId = model.FormOfEducationId;
            courseToUpdate.HoursOfEducation = model.HoursOfEducation;
            courseToUpdate.Credits = model.Credits;
            if (context.Courses.Any(x => x.Name == courseToUpdate.Name && x.StartDate == courseToUpdate.StartDate && x.FormOfEducationId == courseToUpdate.FormOfEducationId))
            {
                throw new Exception();
            }
            await context.SaveChangesAsync();

        }
        public async Task<IEnumerable<AllCoursesViewModel>> AllSearchedAsync(string search)
        {
            Guard.ArgumentNotNull(search, nameof(search));
            return await context.Courses.Where(x => x.Name.ToLower().Contains(search.ToLower()) && x.StartDate.Date < DateTime.Now).Select(p => new AllCoursesViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Place = p.Place,
                StartDate = p.StartDate.ToString(),
                EndDate = p.EndDate.ToString(),
                FormOfEducation = p.FormOfEducation.EductionForm,
                HoursOfEducation = p.HoursOfEducation,
                Credits = p.Credits
            }).ToListAsync();
        }
        public async Task<CourseDetailsViewModel> GetDetailsByIdAsync(string id)
        {
            Course course = await context
                 .Courses
                 .FirstAsync(p => p.Id.ToString() == id);


            CourseDetailsViewModel model = new CourseDetailsViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Place = course.Place,
                StartDate = course.StartDate.ToString(),
                EndDate = course.EndDate.ToString(),
                FormOfEducation = course.FormOfEducation.EductionForm,
                HoursOfEducation = course.HoursOfEducation,
                Credits = course.Credits

            };
            return model;
        }

    }
}
