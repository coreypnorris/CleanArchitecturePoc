using CleanArchitecturePoc.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CleanArchitecturePoc.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SchemaModel _dataContext;

        public UserRepository(SchemaModel schema)
        {
            _dataContext = schema;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _dataContext.Users.Select(u => new UserModel() { Id = u.Id, Email = u.Email });
        }

        // Eager loading example
        public UserModel GetUserWithEnrollments(int userId)
        {
            UserModel user = _dataContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return null;

            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Enrollments = _dataContext.Enrollments.Where(e => e.UserId == userId).ToList()
            };
        }
    }
}