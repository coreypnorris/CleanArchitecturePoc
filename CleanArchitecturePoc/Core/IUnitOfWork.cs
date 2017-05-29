using CleanArchitecturePoc.Core.RepositoryInterfaces;

namespace CleanArchitecturePoc.Core
{
    public interface IUnitOfWork
    {
        ISchemaRepository SchemaContext { get; }
        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        IUserRepository Users { get; }
        void Complete();
    }
}