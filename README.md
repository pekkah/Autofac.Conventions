# Autofac.Conventions

Convention based registration model for Autofac


_NuGet packages are not ready for publishing yet! You can still download and build them yourself!_

## Getting Started


```csharp
// array of possible dependency types
var possibleDependencies = Assembly.GetExecutingAssembly().GetExportedTypes();

// register found dependencies using the builtin marker interface conventions
var builder = new ContainerBuilder();
builder.RegisterUsingConventions(possibleDependencies, MarkerConventions.Default);
IContainer container = builder.Build();

// todo: resolve your registered dependencies from the container

```
