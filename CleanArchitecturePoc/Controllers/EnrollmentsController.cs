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
    [RoutePrefix("Api/Enrollments")]
    public class EnrollmentsController : ApiController
    {
        private readonly SchemaModel _dataContext;
        private readonly EnrollmentRepository _enrollmentRepository;

        public EnrollmentsController()
        {
            _dataContext = new SchemaRepository().GetSchema();
            _enrollmentRepository = new EnrollmentRepository(_dataContext);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<EnrollmentModel> GetEnrollments()
        {
            return _enrollmentRepository.GetEnrollments();
        }

        [HttpGet]
        [Route("ByDate")]
        public IEnumerable<EnrollmentModel> GetEnrollmentsByDate([FromUri] DateTime date)
        {
            return _enrollmentRepository.GetEnrollmentsByDate(date);
        }
    }
}
