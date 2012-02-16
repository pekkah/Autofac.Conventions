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

    public class TransientConventionFacts
    {
        private ContainerBuilder containerBuilder;

        private TransientConvention convention;

        [SetUp]
        public void Context()
        {
            this.convention = new TransientConvention();
            this.containerBuilder = new ContainerBuilder();
        }

        [Test]
        public void should_match_to_transient_dependency()
        {
            var shouldMatch = this.convention.IsMatch(typeof(MockTransientDependency));

            shouldMatch.Should().BeTrue();
        }

        [Test]
        public void should_register_as_transient()
        {
            var dependencyRegistration = this.containerBuilder.RegisterType<MockTransientDependency>();
            this.convention.Apply(dependencyRegistration, typeof(MockTransientDependency));

            var container = this.containerBuilder.Build();
            var registration =
                container.ComponentRegistry.RegistrationsFor(new TypedService(typeof(IMockTransientDependency))).
                    SingleOrDefault();

            registration.Should().NotBeNull();
            registration.Lifetime.Should().BeOfType<CurrentScopeLifetime>();
        }
    }
}