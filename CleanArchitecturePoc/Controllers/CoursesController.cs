using CleanArchitecturePoc.Core.Models;
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
        private readonly IUnitOfWork _unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CourseModel> GetCourses()
        {
            return _unitOfWork.Courses.GetCourses();
        }

        [HttpGet]
        [Route("ByName/{courseName}")]
        public IEnumerable<CourseModel> GetCoursesByName(string courseName)
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