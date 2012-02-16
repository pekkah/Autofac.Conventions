namespace Autofac.Conventions.Tests.StaticMocks
{
    using Autofac.Conventions.MarkerModel;

    public interface IMockTransientDependency : ITransientDependency
    {
    }

    public class MockTransientDependency : IMockTransientDependency
    {
    }
}