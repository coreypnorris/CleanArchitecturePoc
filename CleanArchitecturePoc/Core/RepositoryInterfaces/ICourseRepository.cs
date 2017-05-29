using System.Collections.Generic;
using CleanArchitecturePoc.Core.Models;

namespace CleanArchitecturePoc.Core.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        IEnumerable<CourseModel> GetCourses();
        IEnumerable<CourseModel> GetCoursesByName(string name);
        CourseModel GetCourseWithEnrollments(int courseId);
    }
}