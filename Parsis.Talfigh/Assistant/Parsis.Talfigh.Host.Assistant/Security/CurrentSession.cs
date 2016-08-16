using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Host.Assistant.Security
{
    public class CurrentSession : AuthUserSession
    {
        public string CompanyName { get; set; }

        public string SuperHeroIdentity { get; set; }
    }
}
