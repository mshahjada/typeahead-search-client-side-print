using Autofac;
using Autofac.Integration.WebApi;
using EFApp.Entity;
using EFApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFApp;
using Autofac.Integration.Mvc;

namespace EFApp.App_Start
{
    public class DependencyWebAPIConfig
    {
        public static IContainer container;

        private static readonly Lazy<IContainer> Container = new Lazy<IContainer>(() =>
        {
            var builder = new ContainerBuilder();

            Configure(builder);
            var container = builder.Build();
            //System.Web.Http.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        });

        public static IContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        private static void Configure(ContainerBuilder builder)
        {

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
        }
    }

}