using System.Collections.Generic;
using CleanArchitecturePoc.Models;

namespace CleanArchitecturePoc.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<CourseModel> GetCourses();
        IEnumerable<CourseModel> GetCoursesByName(string name);
        CourseModel GetCourseWithEnrollments(int courseId);
    }
}