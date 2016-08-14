using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsis.Talfigh.DAL.Repository.Base;


namespace Parsis.Talfigh.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbConnectionFactory dbFactory;


        private TestRepository testRepository;
        public ITestRepository TestRepository
        {
            get
            {

                if (this.testRepository == null)
                {
                    this.testRepository = new TestRepository(dbFactory);
                }
                return testRepository;
            }
        }


        public UnitOfWork(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory;
           
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
