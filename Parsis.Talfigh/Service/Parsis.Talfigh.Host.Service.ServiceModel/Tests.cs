using ServiceStack;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Parsis.Talfigh.DAL.Domain.Base;
using System;

namespace Parsis.Talfigh.Service.ServiceModel
{
    [Route("/tests", "GET")]
    [Route("/tests", "POST")]
    [Route("/tests/{Id}", "PUT")]
    [Route("/tests/{Id}", "DELETE")]
   
    public class Tests : IReturn<TestsResponse>
    {
        public long Id { get; set; }
    }


    public class TestsResponse //: IHasResponseStatus
    {
        public TestsResponse()
        {
           // this.ResponseStatus = new ResponseStatus();
            this.Tests = new List<Test>();
        }


       
        public List<Test> Tests { get; set; }


       
      //  public ResponseStatus ResponseStatus { get; set; }
    }
}