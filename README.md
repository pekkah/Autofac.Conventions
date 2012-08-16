# Autofac.Conventions

Convention based registration model for Autofac (Unofficial)

## Getting Started
install-package Autofac.Conventions (packages are not published yet so clone the repository and build the binary)

```csharp
// array of possible dependency types
var possibleDependencies = Assembly.GetExecutingAssembly().GetExportedTypes();

/****************************************************************************** 
* Register found dependencies using the builtin marker interface conventions.
*
* Marker interfaces:
* - ITransientDependency : instance per dependency
* - ISingleInstanceDependency: instance per root container
* - IAsSelf : modifier which registers dependency as self (default: 
*   dependencies are registered by implemented interfaces)
*
*******************************************************************************/
var builder = new ContainerBuilder();
builder.RegisterUsingConventions(possibleDependencies, MarkerConventions.Default);
IContainer container = builder.Build();

// todo: resolve your registered dependencies from the container

```
