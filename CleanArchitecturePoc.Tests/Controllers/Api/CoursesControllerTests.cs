using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanArchitecturePoc.Controllers;
using CleanArchitecturePoc.Persistence;
using Moq;
using CleanArchitecturePoc.Repositories;
using FluentAssertions;
using System.Web.Http.Results;

namespace CleanArchitecturePoc.Tests
{
    [TestClass]
    public class CoursesControllerTests
    {
        private readonly CoursesController _controller;
        public CoursesControllerTests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repository = new Mock<ICourseRepository>();
            unitOfWork.SetupGet(u => u.Courses).Returns(repository.Object);

            _controller = new CoursesController(unitOfWork.Object);
        }

        [TestMethod]
        public void GetCourses_CoursesAreNull_ShouldReturnNotFound()
        {
            var result = _controller.GetCourses();
            result.Should().AllBeOfType<NotFoundResult>();
        }
    }
}
