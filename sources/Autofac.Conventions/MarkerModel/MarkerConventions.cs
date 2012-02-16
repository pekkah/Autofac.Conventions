namespace Autofac.Conventions.MarkerModel
{
    using System.Collections.Generic;

    using Autofac.Conventions.MarkerModel.Conventions;

    public static class MarkerConventions
    {
        public static IEnumerable<IRegistrationConvention> Default
        {
            get
            {
                yield return new SingleInstanceConvention();
                yield return new TransientConvention();
                yield return new AsSelfConvention();
            }
        }
    }
}