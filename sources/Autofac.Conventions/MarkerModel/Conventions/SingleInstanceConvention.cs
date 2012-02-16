namespace Autofac.Conventions.MarkerModel.Conventions
{
    using System;
    using System.Linq;

    using Autofac.Builder;
    using Autofac.Conventions.ExtensionMethods;

    public class SingleInstanceConvention : IRegistrationConvention
    {
        public void Apply(
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> registration,
            Type dependencyType)
        {
            if (registration == null)
            {
                throw new ArgumentNullException("registration");
            }

            if (dependencyType == null)
            {
                throw new ArgumentNullException("dependencyType");
            }

            foreach (
                Type itf in dependencyType.GetInterfaces().Where(i => i.HasInterface(typeof(ISingleInstanceDependency)))
                )
            {
                registration.As(itf).SingleInstance();
            }
        }

        public bool IsMatch(Type type)
        {
            return type.GetInterfaces().Any(i => i.HasInterface(typeof(ISingleInstanceDependency)));
        }
    }
}