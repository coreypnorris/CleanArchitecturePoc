using CleanArchitecturePoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Repositories
{
    public class EnrollmentRepository
    {
        private readonly SchemaModel _dataContext;

        public EnrollmentRepository(SchemaModel schema)
        {
            _dataContext = schema;
        }

        public IEnumerable<EnrollmentModel> GetEnrollments()
        {
            return _dataContext.Enrollments;
        }

        public IEnumerable<EnrollmentModel> GetEnrollmentsByDate(DateTime date)
        {
            return _dataContext.Enrollments.Where(e => e.Date == date);
        }
    }
}