using ServiceStack;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Parsis.Talfigh.DAL.Domain.Base;

namespace Parsis.Talfigh.Service.ServiceModel
{
    [DataContract]
    [Route("/tests")]
    public class Tests
    {
    }

    [DataContract]
    public class TestsResponse : IHasResponseStatus
    {
        public TestsResponse()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Tests = new List<Test>();
        }

        [DataMember]
        public List<Test> Tests { get; set; }

        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
    }
}