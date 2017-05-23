﻿using CleanArchitecturePoc.Models;
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

        public void CreateEnrollment(int courseId, int userId, DateTime date)
        {
            if (date == null) return;
            EnrollmentModel newEnrollment = new EnrollmentModel()
            {
                Id = _dataContext.Enrollments.Count() + 1,
                CourseId = courseId,
                UserId = userId,
                Date = date
            };

            _dataContext.Enrollments.Add(newEnrollment);
            return;
        }

        public IEnumerable<EnrollmentModel> GetEnrollmentsByCourseAndUser(int courseId, int userId)
        {
            return _dataContext.Enrollments.Where(e => e.CourseId == courseId && e.UserId == userId);
        }
    }
}