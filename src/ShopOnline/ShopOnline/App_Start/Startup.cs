using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Business.Services;
using Data;
using Data.Repositories;
using Data.Repositories.imp;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ShopOnline.App_Start.Startup))]

namespace ShopOnline.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<ShopContext>().AsSelf().InstancePerRequest();

            // Đăng kí repository
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(p => p.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Đăng kí services
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                .Where(p => p.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
