using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using NHibernate;
using NHibernate.AspNet.Identity;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using EquipRent.Database;
using EquipRent.WebApplication.Helpers;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EquipRent.WebApplication.App_Start.Ninject), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EquipRent.WebApplication.App_Start.Ninject), "Stop")]

namespace EquipRent.WebApplication.App_Start
{
    public static class Ninject
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<IEquipRentSessionFactory>().To<EquipRentSessionFactory>().InRequestScope();

                RegisterAuthentication(kernel);
                kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<EquipRentSessionFactory>().BindDefaultInterface());
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        private static void RegisterAuthentication(IKernel kernel)
        {
            kernel.Bind<AuthenticationUserManager>().ToSelf();
            kernel.Bind<AuthenticationSignInManager>().ToSelf();
            kernel.Bind<AuthenticationRoleManager>().ToSelf();
            kernel.Bind<System.Security.Principal.IPrincipal>()
              .ToMethod(ctx => HttpContext.Current.User)
              .InRequestScope();
            kernel.Bind<ISession>().ToMethod(x => x.Kernel.Get<IEquipRentSessionFactory>().Session);
            kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
            kernel.Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>().WithConstructorArgument("context",
                context => kernel.Get<IEquipRentSessionFactory>().Session);
        }
    }
}