namespace Autofac.Conventions.Tests
{
    using System;

    using Autofac.Conventions.Tests.StaticMocks;

    using FluentAssertions;

    using NSubstitute;

    using NUnit.Framework;

    using ITypeRegistration =
        Autofac.Builder.IRegistrationBuilder
            <object, Builder.ConcreteReflectionActivatorData, Builder.SingleRegistrationStyle>;

    [TestFixture]
    public class ConventionModelFacts
    {
        [Test]
        public void should_register_dependency_using_A_convention()
        {
            var builder = new ContainerBuilder();
            var dependencyTypes = new[] { typeof(MockDependency) };
            var model = new ConventionModel();

            // convention which should match to IMockDependencyMarker and register it
            var convention = Substitute.For<IRegistrationConvention>();

            // match to IMockDependencyMarker
            convention.IsMatch(Arg.Is<Type>(type => typeof(IMockDependencyMarker).IsAssignableFrom(type))).Returns(true);

            // apply convention
            convention.WhenForAnyArgs(c => c.Apply(null, null)).Do(
                ci =>
                    {
                        var registration = ci.Arg<ITypeRegistration>();
                        registration.As<IMockDependency>();
                    });

            model.Conventions.Add(convention);

            // act
            model.Register(builder, dependencyTypes);
            IContainer container = builder.Build();

            // assert
            var mockDependency = container.ResolveOptional<IMockDependency>();
            mockDependency.Should().NotBeNull();
            mockDependency.Should().BeOfType<MockDependency>();
        }
    }
}