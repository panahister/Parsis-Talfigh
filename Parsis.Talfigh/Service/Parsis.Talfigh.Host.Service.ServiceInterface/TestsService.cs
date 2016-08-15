using Parsis.Talfigh.DAL.Domain.Base;
using Parsis.Talfigh.DAL.Infrastructure;
using Parsis.Talfigh.Service.ServiceInterface;
using Parsis.Talfigh.Service.ServiceModel;
using ServiceStack.OrmLite;

namespace Parsis.Talfigh.Service.ServiceInterface
{
    public class TestsService : ServiceStack.Service
    {
        private IUnitOfWork _uow;

        public TestsService(IUnitOfWork uow )
        {
            _uow = uow;
        }

        public object Get(Tests request)
        {
            //if (!Request.IsSecureConnection)
            //{
            //}
                return new TestsResponse { Tests = _uow.TestRepository.GetAll()};
        }

        public object Post(Tests request)
        {
            
            return new TestsResponse { Tests = _uow.TestRepository.GetAll() };
        }

        public object Put(long id)
        {
           
            return new TestsResponse { Tests = _uow.TestRepository.GetAll() };
        }

        public object Delete(long id)
        {
           
            return new TestsResponse { Tests = _uow.TestRepository.GetAll() };
        }
    }
}
