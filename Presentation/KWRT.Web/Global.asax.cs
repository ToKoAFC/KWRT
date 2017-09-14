using Autofac;
using KWRT.Database.Access.Feature;
using KWRT.Database.Access.Product;
using KWRT.Database.Migrations;
using KWRT.Services.Feature;
using KWRT.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KWRT.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();
            
            builder.RegisterType<KWRTContext>()
                .AsSelf()
                .WithParameter(new NamedParameter("nameOrConnectionString", "name=ResourcerContext"))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductAccess>().As<IProductAccess>().InstancePerLifetimeScope();
            builder.RegisterType<FeatureService>().As<IFeatureService>().InstancePerLifetimeScope();
            builder.RegisterType<FeatureAccess>().As<IFeatureAccess>().InstancePerLifetimeScope();
            IoCConfig.SetupIoC(builder);
        }
    }
}
