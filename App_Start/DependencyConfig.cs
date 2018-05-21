using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EFApp.Entity;
using System.Data.Entity;
using EFApp.Service;
using Autofac.Integration;

namespace EFApp.App_Start
{
    public static class DependencyConfig
    {
        private static readonly Lazy<IContainer> Container = new Lazy<IContainer>(() =>
        {
            var builder = new ContainerBuilder();

            Configure(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        });

        public static IContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        private static void Configure(ContainerBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                cfg.AddProfile<MapperConfig>();
            });

            builder.Register(c => mapperConfig.CreateMapper())
                .Named<IMapper>("TestDB")
                .SingleInstance();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
           

            builder.RegisterFilterProvider();

            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterType<TestDBEntities1>().WithParameters(new[]
            {
                new NamedParameter("connectionString", "TestDBEntities1")
            }).Named<DbContext>("TestDBEntities1").InstancePerDependency();

            builder.Register(c => new ProductService(c.ResolveNamed<IMapper>("TestDB"))).As<IProductService>().InstancePerLifetimeScope();

        }
    }
}