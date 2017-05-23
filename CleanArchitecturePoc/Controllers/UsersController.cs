using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Persistence;
using CleanArchitecturePoc.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace CleanArchitecturePoc.Controllers
{
    [RoutePrefix("Api/Users")]
    public class UsersController : ApiController
    {
        private readonly SchemaModel _schema;
        private readonly UnitOfWork _unitOfWork;

        public UsersController()
        {
            _schema = new SchemaRepository().GetSchema();
            _unitOfWork = new UnitOfWork(_schema);
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