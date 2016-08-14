using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parsis.Talfigh.DAL.Infrastructure
{
    public interface ILiteRepository<T> where T : class
    {
        /// <summary>
        /// Get all elements of type T
        /// </summary>
        List<T> GetAll();
        /// <summary>
        /// Get elements that comply to the specified criteria
        /// </summary>
        List<T> Get(Expression<Func<T, bool>> exp);
        /// <summary>
        /// Get an instance of T with the specified id
        /// </summary>
        T GetById(int id);

        long Insert(T o);

        long Update(T o);

         Task<long> InsertAsync(T o);

        Task<long> UpdateAsync(T o);

        /// <summary>
        /// Inserts or updates instance
        /// </summary>
        bool Save(T o, bool references);

        Task<bool> SaveAsync(T o,bool references);
        /// <summary>
        /// Deletes element with specified id
        /// </summary>
        void Delete(long id);

        Task DeleteAsync(long id);
        /// <summary>
        /// Delete elements that comply to specified criteria
        /// </summary>
        void Delete(Expression<Func<T, bool>> exp);
    }
}
