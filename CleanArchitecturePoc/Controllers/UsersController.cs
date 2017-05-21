using CleanArchitecturePoc.Models;
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
        private readonly SchemaModel _dataContext;
        private readonly UserRepository _userRepository;

        public UsersController()
        {
            _dataContext = new SchemaRepository().GetSchema();
            _userRepository = new UserRepository(_dataContext);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<UserModel> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet]
        [Route("{userId}/WithEnrollments")]
        public UserModel GetUserWithEnrollments(int userId)
        {
            return _userRepository.GetUserWithEnrollments(userId);
        }
    }
}