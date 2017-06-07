# CleanArchitecturePoc
This is a proof-of-concept MVC & Web Api app that implements certain concepts taught in the [Become a Full-stack .NET Developer - Architecture and Testing](https://app.pluralsight.com/library/courses/full-stack-dot-net-developer-architecture-testing/transcript) course at Pluralsight.

The concepts I'm trying to learn / implement in this POC are the following:
- Repository pattern
- Unit of work pattern
- Dependency inversion principle

## Repository pattern
> A **repository** mediates between the domain & data mapping layers using a collection-like interface for accessing domain objects. (Martin Fowler - Patterns of Enterprise Application & Architecture)

Benifits of using repository pattern:
- Minimizes duplicate query logic. Instead of having private methods on controllers, move the query to a Repository class & use it in all controllers.
- Provides better seperation of concerns. If all query logic is moved out of controllers, then controllers are not responsible for that. Controllers should not be part of data access layer. Controllers should delegate logic to other layers & only focus on accepting requests & returning responses.
- Decouples the app from persistence frameworks (like Entity Framework). If you want to switch ORMs in the future then you can do so with minimal inpact.

Repositories should not be used for saving data to a database.
> In a business transaction it's possible to work with multiple repositories. If you're going to add a save method to a repository, which repository should have the save method? Both of them? That means we need to make two separate calls to persist changes in each domain objects. But what about the transaction? What if both changes have to be persistent together? Based on the definition of the repository pattern in Martin Fowler's book, a **repository** is like a collection of domain objects in memory. It's contract (public methods) should not reflect anything about a database. Saving changes is the responsibility of unit of work.

See the following files in this project for examples of a repository pattern:
- CleanArchitecturePoc\Persistence\Repositories\CourseRepository.cs
- CleanArchitecturePoc\Persistence\Repositories\EnrollmentRepository.cs
- CleanArchitecturePoc\Persistence\Repositories\UserRepository.cs

## Unit of work pattern
> A **unit of work** maintains a list of objects affected by a business transaction & coordinates the writing out of changes. (Martin Fowler - Patterns of Enterprise Application & Architecture)

Saving changes to the persistence layer is the responsibility of unit of work.

See file CleanArchitecturePoc\Persistence\UnitOfWork.cs in this project for an example of a unit of work pattern.

## Dependency inversion principle
> The definition of **dependency inversion principle** has two parts. The first part is that high-level modules should not depend on low-level modules. Both should depend on abstractions.

![alt text](http://i.imgur.com/oQzlzy2.png)

In this example a controller is dependent on unit of work. That is a violation of the first part of dependency inversion principle.

![alt text](http://i.imgur.com/OCA8i4S.png)

In this example both the controller & unit of work implement an interface called IUnitOfWork. The controller is no longer dependent on the concrete implementation in UnitOfWork. As long as the interface is kept clean the implementation can be changed without affecting the logic in the controller.

> The definition of **dependency inversion principle** has two parts. The second part is that abstractions should not depend on details. Details should depend on abstractions.

![alt text](http://i.imgur.com/0J0wCJY.png)

In this example an abstraction, IUnitOfWork, is dependent on the details in GigRepository. This is a violation of the second part of the dependency inversion principle.

![alt text](http://i.imgur.com/Wyblb6U.png)

In this example the same abstraction, IUnitOfWork, is dependent on another abstraction, IGigRepository. IUnitOfWork is no longer dependent on the concrete implementation in GigRepository. As long as the interface, IGigRepository, is kept clean the implementation can be changed without affecting the logic in the UnitOfWork.
