namespace SmartTeacher.Common
{
    public static class EntityValidationConstants
    {
        public class Course
        {
            public const int NameMinLenght = 5;
            public const int NameMaxLength = 20;
            public const string NameErrorMessage = "The course name must be between 5 and 20 letters long!";

            public const int PlaceMinLenght = 5;
            public const int PlaceMaxLength = 20;
            public const string PlaceErrorMessage = "The course place must be between 5 and 20 letters long!";

            public const int EducationOrganisationMinLenght = 5;
            public const int EducationOrganisationMaxLength = 20;
            public const string EducationOrganisationErrorMessage = "The course place must be between 5 and 20 letters long!";
        }
        public class Diploma
        {
            public const int InstitutionMinLenght = 5;
            public const int InstitutionMaxLength = 60;
            public const string InstitutionErrorMessage = "The institution name must be between 5 and 20 letters long!";

            public const int SpecificationMinLenght = 5;
            public const int SpecificationMaxLength = 50;
            public const string SpecificationErrorMessage = "The specification name must be between 5 and 20 letters long!";

             public const int DiplomaNumberMinLenght = 5;
            public const int DiplomaNumberMaxLength = 50;
            public const string DiplomaNumberErrorMessage = "The specification name must be between 5 and 20 letters long!";
        }
        public class School
        {
            public const int FullNameMinLenght = 10;
            public const int FullNameMaxLength = 60;
            public const string FullNameErrorMessage = "The name should be between 10 and 60";

            public const int AddressNumberMinLenght = 5;
            public const int AddressNumberMaxLength = 40;
            public const string AddressNumberErrorMessage = "The address should be between 5 and 40 letters long!";
        }
        public class Teacher
        {
            public const int FirstNameMinLenght = 3;
            public const int FirstNameMaxLength = 15;
            public const string FirstNameErrorMessage = "The first name should be between 10 and 60";

            public const int MiddleNameMinLenght = 5;
            public const int MiddleNameMaxLength = 20;
            public const string MiddleNameErrorMessage = "The middle name should be between 10 and 60";

            public const int LastNameMinLenght = 5;
            public const int LastNameMaxLength = 20;
            public const string LastNameErrorMessage = "The last name should be between 10 and 60";

            public const int BirthplaceMinLenght = 3;
            public const int BirthplaceMaxLength = 20;
            public const string BirthplaceErrorMessage = "The birthplace should be between 10 and 60";

            public const int PossitionMinLenght = 5;
            public const int PossitionMaxLength = 20;
            public const string PossitionErrorMessage = "The possition should be between 10 and 60";

            public const int SubjectMinLenght = 2;
            public const int SubjectMaxLength = 20;
            public const string SubjectErrorMessage = "The subject should be between 10 and 60";

        }
    }
}