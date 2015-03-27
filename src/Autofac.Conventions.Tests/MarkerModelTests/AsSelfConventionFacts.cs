namespace Autofac.Conventions.Tests.MarkerModelTests
{
    using System.Linq;

    using Autofac.Conventions.MarkerModel.Conventions;
    using Autofac.Conventions.Tests.StaticMocks;
    using Autofac.Core;
    using Autofac.Core.Lifetime;

    using FluentAssertions;

    using NUnit.Framework;

    public class AsSelfConventionFacts
    {
        private ContainerBuilder containerBuilder;

        private AsSelfConvention convention;

        [SetUp]
        public void Context()
        {
            this.convention = new AsSelfConvention();
            this.containerBuilder = new ContainerBuilder();
        }

        [Test]
        public void should_match_to_as_self()
        {
            bool shouldMatch = this.convention.IsMatch(typeof(MockTransientAsSelfDependency));

            shouldMatch.Should().BeTrue();
        }

        [Test]
        public void should_register_as_transient()
        {
            var dependencyRegistration = this.containerBuilder.RegisterType<MockTransientAsSelfDependency>();
            this.convention.Apply(dependencyRegistration, typeof(MockTransientAsSelfDependency));

            IContainer container = this.containerBuilder.Build();
            IComponentRegistration registration =
                container.ComponentRegistry.RegistrationsFor(new TypedService(typeof(MockTransientAsSelfDependency))).
                    SingleOrDefault();

            registration.Should().NotBeNull();
            registration.Lifetime.Should().BeOfType<CurrentScopeLifetime>();
        }
    }
}