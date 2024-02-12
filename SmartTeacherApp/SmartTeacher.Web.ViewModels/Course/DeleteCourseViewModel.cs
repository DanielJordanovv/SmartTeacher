﻿using SmartTeacher.Data.Models.SeederTables;
using SmartTeacher.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SmartTeacher.Common.EntityValidationConstants.Course;

namespace SmartTeacher.Web.ViewModels.Course
{
    public class DeleteCourseViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(NameMaxLength, ErrorMessage = NameErrorMessage, MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(PlaceMaxLength, ErrorMessage = PlaceErrorMessage, MinimumLength = PlaceMinLenght)]
        public string Place { get; set; } = null!;
        [Required]
        [StringLength(PlaceMaxLength, ErrorMessage = EducationOrganisationErrorMessage, MinimumLength = EducationOrganisationMinLenght)]
        public string EducationOrganisiation { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [ForeignKey("FormOfEducation")]
        public int FormOfEducationId { get; set; }
        public virtual FormOfEducation FormOfEducation { get; set; } = null!;
        public int HoursOfEducation { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
        public string SchoolId { get; set; }
        public virtual SmartTeacher.Data.Models.School School { get; set; } = null!;
    }
}

