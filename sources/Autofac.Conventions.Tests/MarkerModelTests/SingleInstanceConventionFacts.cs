namespace Autofac.Conventions.Tests.MarkerModelTests
{
    using System.Linq;

    using Autofac;
    using Autofac.Conventions.MarkerModel.Conventions;
    using Autofac.Conventions.Tests.StaticMocks;
    using Autofac.Core;
    using Autofac.Core.Lifetime;

    using FluentAssertions;

    using NUnit.Framework;

    public class SingleInstanceConventionFacts
    {
        private ContainerBuilder containerBuilder;

        private SingleInstanceConvention convention;

        [SetUp]
        public void Context()
        {
            this.convention = new SingleInstanceConvention();
            this.containerBuilder = new ContainerBuilder();
        }

        [Test]
        public void should_match_to_singleInstance_dependency()
        {
            var shouldMatch = this.convention.IsMatch(typeof(MockSingleInstanceDependency));

            shouldMatch.Should().BeTrue();
        }

        [Test]
        public void should_register_as_single_instance()
        {
            var dependencyRegistration = this.containerBuilder.RegisterType<MockSingleInstanceDependency>();
            this.convention.Apply(dependencyRegistration, typeof(MockSingleInstanceDependency));

            var container = this.containerBuilder.Build();
            var registration =
                container.ComponentRegistry.RegistrationsFor(new TypedService(typeof(IMockSingleInstanceDependency))).
                    SingleOrDefault();

            registration.Should().NotBeNull();
            registration.Lifetime.Should().BeOfType<RootScopeLifetime>();
        }
    }
}