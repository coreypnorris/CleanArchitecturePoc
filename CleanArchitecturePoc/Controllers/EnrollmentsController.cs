using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Persistence;
using CleanArchitecturePoc.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleanArchitecturePoc.Controllers
{
    [RoutePrefix("Api/Enrollments")]
    public class EnrollmentsController : ApiController
    {
        private readonly SchemaModel _schema;
        private readonly UnitOfWork _unitOfWork;

        public EnrollmentsController()
        {
            _schema = new SchemaRepository().GetSchema();
            _unitOfWork = new UnitOfWork(_schema);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<EnrollmentModel> GetEnrollments()
        {
            return _unitOfWork.Enrollments.GetEnrollments();
        }

        [HttpGet]
        [Route("ByDate")]
        public IEnumerable<EnrollmentModel> GetEnrollmentsByDate([FromUri] DateTime date)
        {
            return _unitOfWork.Enrollments.GetEnrollmentsByDate(date);
        }

        [HttpPost]
        [Route("Course/{courseId}/User/{userId}")]
        public IEnumerable<EnrollmentModel> CreateEnrollment(int courseId, int userId, [FromUri] DateTime date)
        {
            _unitOfWork.Enrollments.CreateEnrollment(courseId, userId, date);
            _unitOfWork.Complete();
            return _unitOfWork.Enrollments.GetEnrollmentsByCourseAndUser(courseId, userId);
        }
    }
}
