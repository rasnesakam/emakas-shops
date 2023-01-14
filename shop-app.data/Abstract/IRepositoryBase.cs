using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace shop_app.data.Abstract
{
    public interface IRepositoryBase<E>
    {
        /// <summary>
        /// Get Data by it's id
        /// </summary>
        /// <param name="id">
        /// id of data that requested
        /// </param>
        /// <returns>
        /// Data that requested
        /// </returns>
        /// <exception cref="shop_app.data.Exceptions.NoElementFoundException">
        /// in case of no element found
        /// </exception>
        Task<E> GetById(Guid id);

        /// <summary>
        /// Gets All datas from database
        /// </summary>
        /// <returns>List of datas</returns>
        /// <exception cref="shop_app.data.Exceptions.NoElementFoundException">
        /// Throws when no data founded
        /// </exception>
		Task<IEnumerable<E>> GetAll();

        /// <summary>
        /// Get datas as part as defined with start and size
        /// </summary>
        /// <param name="start">
        /// Skips start datas from beginning
        /// </param>
        /// <param name="size">
        /// Collects size datas for list
        /// </param>
        /// <returns>
        /// Enumerable list of entity
        /// </returns>
        /// <exception cref="shop_app.data.Exceptions.NoElementFoundException">
        /// Throws when no data found
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when illegal arguments passed
        /// </exception>
        Task<IEnumerable<E>> GetPart(int start, int size);

        /// <summary>
        /// Gets elements by filtered as predicate
        /// </summary>
        /// <param name="predicate">
        /// Filter for the datas.
        /// </param>
        /// <param name="included">
        /// Included entities for the data that requested
        /// </param>
        /// <returns>
        /// Enumerable list of requested datas
        /// </returns>
        Task<IEnumerable<E>> GetAllBy(Expression<Func<E,bool>> predicate, params Expression<Func<E, object>>[] included);

        /// <summary>
        /// Create a data in the database
        /// </summary>
        /// <param name="entity">
        /// Candidate data to be creates
        /// </param>
        /// <returns></returns>
		Task Create(E entity);
        
        /// <summary>
        /// Update existing data in the database
        /// </summary>
        /// <param name="entity">
        /// Candidate data to be creates
        /// </param>
        /// <returns></returns>
		Task Update(E entity);

        /// <summary>
        /// Delete the data from the database
        /// </summary>
        /// <param name="entity">
        /// Candidate data to be creates
        /// </param>
        /// <returns></returns>
        Task Delete(E entity);

        /// <summary>
        /// Save changes for database database.
        /// Finish proccesses.
        /// </summary>
        /// <param name="entity">
        /// Candidate data to be creates
        /// </param>
        /// <returns></returns>
        Task<int> SaveChanges();
    }
}