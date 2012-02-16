namespace Autofac.Conventions.Tests.StaticMocks
{
    using Autofac.Conventions.MarkerModel;

    public interface IMockSingleInstanceDependency : ISingleInstanceDependency
    {
    }

    public class MockSingleInstanceDependency : IMockSingleInstanceDependency
    {
    }
}