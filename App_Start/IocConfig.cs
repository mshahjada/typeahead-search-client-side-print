using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using EFApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EFApp.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            //builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            //builder.Register<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            //builder.RegisterType<ProductService>().AsSelf().InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;


        }
    }
}