using System;
using System.Collections.Generic;
using CleanArchitecturePoc.Core.Models;

namespace CleanArchitecturePoc.Core.RepositoryInterfaces
{
    public interface IEnrollmentRepository
    {
        void CreateEnrollment(int courseId, int userId, DateTime date);
        IEnumerable<EnrollmentModel> GetEnrollments();
        IEnumerable<EnrollmentModel> GetEnrollmentsByCourseAndUser(int courseId, int userId);
        IEnumerable<EnrollmentModel> GetEnrollmentsByDate(DateTime date);
    }
}