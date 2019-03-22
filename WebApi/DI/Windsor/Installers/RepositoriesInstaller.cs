using AA.Infrastructure.Interfaces;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using WebApi.Connections;

namespace ADit.DI.Windsor.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                  Component.For(typeof(IEnvironment))
                      .ImplementedBy(typeof(Environment))
                      .Named("Environment")
                      .LifeStyle.Is(LifestyleType.Transient));



            container.Register(
         Component.For(typeof(IUserRepo))
             .ImplementedBy(typeof(UserRepo))
             .Named("UserRepo")
             .LifeStyle.Is(LifestyleType.Transient));
        }
    }
}