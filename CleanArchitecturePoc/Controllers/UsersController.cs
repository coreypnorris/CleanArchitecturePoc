﻿using CleanArchitecturePoc.Core.Models;
using CleanArchitecturePoc.Persistence;
using CleanArchitecturePoc.Core.RepositoryInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using CleanArchitecturePoc.Core;

namespace CleanArchitecturePoc.Controllers
{
    [RoutePrefix("Api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<UserModel> GetUsers()
        {
            return _unitOfWork.Users.GetUsers();
        }

        [HttpGet]
        [Route("{userId}/WithEnrollments")]
        public UserModel GetUserWithEnrollments(int userId)
        {
            return _unitOfWork.Users.GetUserWithEnrollments(userId);
        }
    }
}