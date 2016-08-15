using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using ServiceStack;
using ServiceStack.Mvc;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.DAL.Repository.Base;
using ServiceStack.Admin;
using Parsis.Talfigh.Service.ServiceInterface;

namespace Parsis.Talfigh.Host
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("Parsis.Talfigh.Host", typeof(TestsService).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
            });
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            //Set MVC to use the same Funq IOC as ServiceStack
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            container.Register<IDbConnectionFactory>(
            new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["TalfighConnection"].ConnectionString, SqlServerDialect.Provider));

            container.RegisterAutoWiredType(typeof(UnitOfWork), typeof(IUnitOfWork));
            container.RegisterAutoWiredType(typeof(TestRepository), typeof(ITestRepository));

            Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });
            Plugins.Add(new AdminFeature());

            Plugins.Add(new CorsFeature());

            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json
            });
        }
    }
}