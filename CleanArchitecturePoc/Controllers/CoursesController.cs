using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Persistence;
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
        private readonly SchemaModel _schema;
        private readonly UnitOfWork _unitOfWork;

        public CoursesController()
        {
            _schema = new SchemaRepository().GetSchema();
            _unitOfWork = new UnitOfWork(_schema);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CourseModel> GetCourse()
        {
            return _unitOfWork.Courses.GetCourses();
        }

        [HttpGet]
        [Route("ByName/{courseName}")]
        public IEnumerable<CourseModel> GetCourseByName(string courseName)
        {
            return _unitOfWork.Courses.GetCoursesByName(courseName);
        }

        [HttpGet]
        [Route("{courseId}/WithEnrollments")]
        public CourseModel GetCourseWithEnrollments(int courseId)
        {
            return _unitOfWork.Courses.GetCourseWithEnrollments(courseId);
        }
    }
}