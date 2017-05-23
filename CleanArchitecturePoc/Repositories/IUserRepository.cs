using System.Collections.Generic;
using CleanArchitecturePoc.Models;

namespace CleanArchitecturePoc.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserWithEnrollments(int userId);
    }
}