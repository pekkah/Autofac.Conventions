namespace Autofac.Conventions
{
    using System;
    using System.Collections.Generic;

    public static class ContainerBuiderExtensions
    {
        public static void RegisterUsingConventions(
            this ContainerBuilder builder,
            IEnumerable<Type> possibleTypes,
            IEnumerable<IRegistrationConvention> conventions)
        {
            var model = new ConventionModel();
            model.Conventions.AddRange(conventions);
            model.Register(builder, possibleTypes);
        }
    }
}