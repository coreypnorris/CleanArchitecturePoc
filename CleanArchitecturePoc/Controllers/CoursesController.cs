using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleanArchitecturePoc.Controllers
{
    [RoutePrefix("Api/Courses")]
    public class CoursesController : ApiController
    {
        private readonly SchemaModel _dataContext;
        private readonly CourseRepository _courseRepository;

        public CoursesController()
        {
            _dataContext = new SchemaRepository().GetSchema();
            _courseRepository = new CourseRepository(_dataContext);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CourseModel> GetCourse()
        {
            return _courseRepository.GetCourses();
        }

        [HttpGet]
        [Route("ByName/{courseName}")]
        public IEnumerable<CourseModel> GetCourseByName(string courseName)
        {
            return _courseRepository.GetCoursesByName(courseName);
        }

        [HttpGet]
        [Route("{courseId}/WithEnrollments")]
        public CourseModel GetCourseWithEnrollments(int courseId)
        {
            return _courseRepository.GetCourseWithEnrollments(courseId);
        }
    }
}