using CleanArchitecturePoc.Repositories;

namespace CleanArchitecturePoc.Persistence
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        IUserRepository Users { get; }
        void Complete();
    }
}