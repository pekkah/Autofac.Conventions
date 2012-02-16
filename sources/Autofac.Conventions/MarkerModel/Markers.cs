namespace Autofac.Conventions.MarkerModel
{
    using System.Collections.Generic;

    using Autofac.Conventions.MarkerModel.Conventions;

    public static class Markers
    {
        public static IEnumerable<IRegistrationConvention> Defaults
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