# CleanArchitecturePoc
This is a proof-of-concept MVC & Web Api app that implements certain concepts taught in the [Become a Full-stack .NET Developer - Architecture and Testing](https://app.pluralsight.com/library/courses/full-stack-dot-net-developer-architecture-testing/transcript) course at Pluralsight.

The concepts I'm trying to learn / implement in this POC are the following:
- Repository pattern
- Unit of work pattern
- Dependency inversion principle (TODO)

## Repository pattern
> A **repository** mediates between the domain & data mapping layers using a collection-like interface for accessing domain objects. (Martin Fowler - Patterns of Enterprise Application & Architecture)

Benifits of using repository pattern:
- Minimizes duplicate query logic. Instead of having private methods on controllers, move the query to a Repository class & use it in all controllers.
- Provides better seperation of concerns. If all query logic is moved out of controllers, then controllers are not responsible for that. Controllers should not be part of data access layer. Controllers should delegate logic to other layers & only focus on accepting requests & returning responses.
- Decouples the app from persistence frameworks (like Entity Framework). If you want to switch ORMs in the future then you can do so with minimal inpact.

See the following files in this project for examples of a repository pattern:
- CleanArchitecturePoc\Persistence\Repositories\CourseRepository.cs
- CleanArchitecturePoc\Persistence\Repositories\EnrollmentRepository.cs
- CleanArchitecturePoc\Persistence\Repositories\UserRepository.cs

Repositories should not be used for saving data to a database:
> In a business transaction it's possible to work with multiple repositories. If you're going to add a save method to a repository, which repository should have the save method? Both of them? That means we need to make two separate calls to persist changes in each domain objects. But what about the transaction? What if both changes have to be persistent together? Based on the definition of the repository pattern in Martin Fowler's book, a **repository** is like a collection of domain objects in memory. It's contract (public methods) should not reflect anything about a database. Saving changes is the responsibility of unit of work. (Mosh Hamedani - [Become a Full-stack .NET Developer - Architecture and Testing](https://app.pluralsight.com/library/courses/full-stack-dot-net-developer-architecture-testing/transcript))


## Unit of work pattern
> A **unit of work** maintains a list of objects affected by a business transaction & coordinates the writing out of changes. (Martin Fowler - Patterns of Enterprise Application & Architecture)

Saving changes to the persistence layer is the responsibility of unit of work.

See file CleanArchitecturePoc\Persistence\UnitOfWork.cs in this project for an example of a unit of work pattern.
