using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsis.Talfigh.DAL.Repository.Base;


namespace Parsis.Talfigh.DAL.Infrastructure
{
    public interface IUnitOfWork
    {

        ITestRepository TestRepository { get; }


    }
}
