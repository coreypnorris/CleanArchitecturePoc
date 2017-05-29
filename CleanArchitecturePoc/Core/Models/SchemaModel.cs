using System.Collections.Generic;

namespace CleanArchitecturePoc.Core.Models
{
    public class SchemaModel
    {
        public List<UserModel> Users { get; set; }
        public List<CourseModel> Courses { get; set; }
        public List<EnrollmentModel> Enrollments { get; set; }
    }
}