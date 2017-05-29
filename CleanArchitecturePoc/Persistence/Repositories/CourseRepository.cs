using CleanArchitecturePoc.Core.Models;
using CleanArchitecturePoc.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchemaModel _dataContext;
        public CourseRepository(SchemaModel schema)
        {
            _dataContext = schema;
        }

        public IEnumerable<CourseModel> GetCourses()
        {
            return _dataContext.Courses;
        }

        public IEnumerable<CourseModel> GetCoursesByName(string name)
        {
            return _dataContext.Courses.Where(c => c.Name == name);
        }

        public CourseModel GetCourseWithEnrollments(int courseId)
        {
            CourseModel course = _dataContext.Courses.FirstOrDefault(u => u.Id == courseId);
            if (course == null)
            {
                return null;
            }

            return new CourseModel()
            {
                Id = course.Id,
                Name = course.Name,
                Enrollments = _dataContext.Enrollments.Where(e => e.CourseId == courseId).ToList()
            };
        }
    }
}