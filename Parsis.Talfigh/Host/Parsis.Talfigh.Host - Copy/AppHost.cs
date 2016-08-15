using Funq;
using ServiceStack;
using Parsis.Talfigh.Service.ServiceInterface;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using ServiceStack.Admin;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.DAL.Repository.Base;

namespace Parsis.Talfigh.Host
{
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("Parsis.Talfigh.Host", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {

            container.Register<IDbConnectionFactory>(
             new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["TalfighConnection"].ConnectionString, SqlServerDialect.Provider));

            container.RegisterAutoWiredType(typeof(UnitOfWork), typeof(IUnitOfWork));
            container.RegisterAutoWiredType(typeof(TestRepository), typeof(ITestRepository));

            Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });
            Plugins.Add(new AdminFeature());

            Plugins.Add(new CorsFeature());
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
        }
    }
}
