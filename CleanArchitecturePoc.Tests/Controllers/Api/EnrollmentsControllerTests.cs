using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanArchitecturePoc.Controllers;
using CleanArchitecturePoc.Persistence;
using Moq;
using CleanArchitecturePoc.Repositories;
using FluentAssertions;
using System.Web.Http.Results;
using CleanArchitecturePoc.Core.Models;
using System.Collections.Generic;

namespace CleanArchitecturePoc.Tests
{
    [TestClass]
    public class EnrollmentsControllerTests
    {
        private readonly EnrollmentsController _controller;
        private readonly Mock<IEnrollmentRepository> _enrollmentRepo;
        private readonly List<EnrollmentModel> _testEnrollments;

        public EnrollmentsControllerTests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            _enrollmentRepo = new Mock<IEnrollmentRepository>();
            unitOfWork.SetupGet(u => u.Enrollments).Returns(_enrollmentRepo.Object);
            _controller = new EnrollmentsController(unitOfWork.Object);

            _testEnrollments = new List<EnrollmentModel>
            {
                new EnrollmentModel(){Date=DateTime.Now},
                new EnrollmentModel(){Date=DateTime.Now},
                new EnrollmentModel(){Date=DateTime.Now},
            };
        }

        [TestMethod]
        public void GetEnrollments_EnrollmentssAreNull_ShouldReturnNotFound()
        {
            var result = _controller.GetEnrollments();
            result.Should().AllBeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void GetCourses_EnrollmentsAreNotNull_ShouldReturnEnrollments()
        {
            _enrollmentRepo.Setup(r => r.GetEnrollments()).Returns(_testEnrollments);
            var result = _controller.GetEnrollments();
            result.Should().AllBeOfType<EnrollmentModel>();
        }
    }
}
