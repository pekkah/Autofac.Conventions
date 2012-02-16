namespace Autofac.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Autofac.Builder;

    public class ConventionModel
    {
        public ConventionModel()
        {
            this.Conventions = new List<IRegistrationConvention>();
        }

        public List<IRegistrationConvention> Conventions { get; private set; }

        public void Register(ContainerBuilder builder, IEnumerable<Type> possibleTypes)
        {
            foreach (Type possibleType in this.DiscoverDependencies(possibleTypes))
            {
                this.InternalRegister(builder, possibleType);
            }
        }

        public void Register(ContainerBuilder builder, Type possibleType)
        {
            if (!this.IsDependency(possibleType))
            {
                throw new ArgumentException(
                    string.Format(
                        "Type {0} is not recognized by any convention as dependency type.", possibleType.FullName),
                    "possibleType");
            }

            this.InternalRegister(builder, possibleType);
        }

        private IEnumerable<Type> DiscoverDependencies(IEnumerable<Type> possibleTypes)
        {
            return possibleTypes.Where(this.IsDependency);
        }

        private void InternalRegister(ContainerBuilder builder, Type dependencyType)
        {
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> registration =
                builder.RegisterType(dependencyType);
            foreach (IRegistrationConvention policy in this.Conventions.Where(p => p.IsMatch(dependencyType)))
            {
                policy.Apply(registration, dependencyType);
            }
        }

        private bool IsDependency(Type possibleType)
        {
            return this.Conventions.Any(convention => convention.IsMatch(possibleType));
        }
    }
}