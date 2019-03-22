using Castle.MicroKernel.Registration;
using Castle.Core;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Data.Entity.Infrastructure;
using WebApi.DataAccess;

namespace ADit.DI.Windsor.Installers
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IDbContextFactory))
                    .ImplementedBy(typeof(DbContextFactory))
                    .Named("DbContextFactory")
                    .LifeStyle.Is(LifestyleType.Pooled));



           




        }
    }
}