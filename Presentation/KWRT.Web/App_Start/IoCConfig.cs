using Autofac;
using Autofac.Integration.Mvc;
using KWRT.Database.Migrations;
using System.Reflection;
using System.Web.Mvc;

namespace KWRT.Web
{
    public class IoCConfig
    {
        public static void SetupIoC(ContainerBuilder builder)
        {
            // Register something that I don't know what it is.
            builder.RegisterFilterProvider();

            // Register controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

           
            // Register other dependencies.
            builder.RegisterType<KWRTContext>().AsSelf().InstancePerLifetimeScope();

            // Build the container.
            var container = builder.Build();

            // Resolver for MVC.
            var mvc_resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvc_resolver);
            
        }
    }
}
