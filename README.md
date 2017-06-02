# CleanArchitecturePoc
This is a proof-of-concept MVC & Web Api app that implements certain concepts taught in the [Become a Full-stack .NET Developer - Architecture and Testing](https://app.pluralsight.com/library/courses/full-stack-dot-net-developer-architecture-testing/transcript) course at Pluralsight.

The concepts I'm trying to implement in this POC are the following:
- Repository pattern (TODO)
- Unit of work pattern (TODO)
- Dependency inversion principle (TODO)

## Repository pattern
Repository definition:
> Mediates between the domain & data mapping layers using a collection-like interface for accessing domain objects.
> Martin Fowler - Patterns of Enterprise Application & Architecture

Benifits of using Repository pattern:
- Minimizes duplicate query logic. Instead of having private methods on controllers, move the query to a Repository class & use it in all controllers.

- Provides better seperation of concerns. If all query logic is moved out of controllers, then controllers are not responsible for that. Controllers should not be part of data access layer. Controllers should delegate logic to other layers & only focus on accepting requests & returning responses.

- Decouples the app from persistence frameworks (like Entity Framework). If you want to switch ORMs in the future then you can do so with minimal inpact.
