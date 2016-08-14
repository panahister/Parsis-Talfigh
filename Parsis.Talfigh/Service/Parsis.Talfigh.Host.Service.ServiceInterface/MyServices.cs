using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Parsis.Talfigh.Service.ServiceModel;

namespace Parsis.Talfigh.Service.ServiceInterface
{
    public class MyServices : ServiceStack.Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello, {0}!".Fmt(request.Name) };
        }
    }
}