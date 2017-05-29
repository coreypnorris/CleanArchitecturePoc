using System.Collections.Generic;
using CleanArchitecturePoc.Core.Models;

namespace CleanArchitecturePoc.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserWithEnrollments(int userId);
    }
}