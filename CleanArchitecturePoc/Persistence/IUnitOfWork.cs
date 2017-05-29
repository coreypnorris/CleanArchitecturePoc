using CleanArchitecturePoc.Core.RepositoryInterfaces;

namespace CleanArchitecturePoc.Persistence
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