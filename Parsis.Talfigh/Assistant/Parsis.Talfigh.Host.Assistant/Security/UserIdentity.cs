using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.Host.Assistant.Security
{
    public class UserIdentity : ServiceStack.Service
    {

        private static UserIdentity instance = null;
        private static readonly object padlock = new object();

        UserIdentity()
        {
        }

        public static UserIdentity Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserIdentity();
                    }
                    return instance;
                }
            }
        }


        public CurrentSession CustomUserSession
        {
            get
            {
                return SessionAs<CurrentSession>();
            }
        }


    }
}
