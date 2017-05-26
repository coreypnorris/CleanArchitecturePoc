using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanArchitecturePoc.Controllers;
using CleanArchitecturePoc.Persistence;
using Moq;
using CleanArchitecturePoc.Repositories;
using FluentAssertions;
using System.Web.Http.Results;
using CleanArchitecturePoc.Models;
using System.Collections.Generic;

namespace CleanArchitecturePoc.Tests
{
    [TestClass]
    public class CoursesControllerTests
    {
        private readonly CoursesController _controller;
        private readonly Mock<ICourseRepository> _courseRepo;
        private readonly List<CourseModel> _testCourses;

        public CoursesControllerTests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            _courseRepo = new Mock<ICourseRepository>();
            unitOfWork.SetupGet(u => u.Courses).Returns(_courseRepo.Object);
            _controller = new CoursesController(unitOfWork.Object);

            _testCourses = new List<CourseModel>
            {
                new CourseModel(){Name="Foo"},
                new CourseModel(){Name="Bar"},
                new CourseModel(){Name="Baz"},
            };
        }

        [TestMethod]
        public void GetCourses_CoursesAreNull_ShouldReturnNotFound()
        {
            var result = _controller.GetCourses();
            result.Should().AllBeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void GetCourses_CoursesAreNotNull_ShouldReturnCourses()
        {
            _courseRepo.Setup(r => r.GetCourses()).Returns(_testCourses);
            var result = _controller.GetCourses();
            result.Should().AllBeOfType<CourseModel>();
        }

        [TestMethod]
        public void GetCourseByName_NameIsNull_ShouldReturnNotFound()
        {
            var result = _controller.GetCoursesByName(null);
            result.Should().AllBeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void GetCourseByName_NameIsNotNull_ShouldReturnCourses()
        {
            var testCourses = new List<CourseModel>
            {
                new CourseModel(){Name="Foo"},
                new CourseModel(){Name="Foo"},
            };
            _courseRepo.Setup(r => r.GetCoursesByName("Foo")).Returns(_testCourses);
            var result = _controller.GetCoursesByName("Foo");
            result.Should().AllBeOfType<CourseModel>();
        }
    }
}
