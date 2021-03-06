namespace Autofac.Conventions
{
    using System;

    using Autofac.Builder;

    public interface IRegistrationConvention
    {
        void Apply(
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> registration,
            Type dependencyType);

        bool IsMatch(Type type);
    }
}