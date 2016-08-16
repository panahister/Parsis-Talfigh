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
using ServiceStack.Auth;
using ServiceStack.Configuration;
using Parsis.Talfigh.Host.Assistant.Security;
using ServiceStack.Caching;
using ServiceStack.Web;
using Parsis.Talfigh.Business.Service;

namespace Parsis.Talfigh.Host
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("Parsis.Talfigh.Host", typeof(TestsService).Assembly) { }

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
            });

            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            container.Register<IDbConnectionFactory>(
            new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["TalfighConnection"].ConnectionString, SqlServerDialect.Provider));

            container.RegisterAutoWiredType(typeof(UnitOfWork), typeof(IUnitOfWork));

            container.RegisterAutoWiredType(typeof(TestRepository), typeof(ITestRepository));

            container.RegisterAutoWiredType(typeof(TestService), typeof(ITestService));



            Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });

            Plugins.Add(new AdminFeature());

            Plugins.Add(new CorsFeature());

            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json
            });

            SetConfig(new HostConfig { DebugMode = true });

            this.ServiceExceptionHandlers.Add((httpReq, request, exception) =>
            {
                var dd = (HttpError)exception;
                return new HttpError(401, "ssss", "ssss");


            });

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<ISessionFactory>(c => new SessionFactory(c.Resolve<ICacheClient>()));


            Plugins.Add(new AuthFeature(
                () => new CurrentSession(),
                new IAuthProvider[]
                {
                    new PasisCredentialsAuthProvider(),
                    new BasicAuthProvider()
                }, "http://www.google.com")
            );


        }
    }
}