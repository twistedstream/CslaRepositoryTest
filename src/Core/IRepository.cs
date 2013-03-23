using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.Core
{


    /// <summary>
    /// Represents a data access repository.
    /// </summary>
    /// <typeparam name="TContext">
    /// The type of repository context that this repository creates.
    /// </typeparam>
    public interface IRepository<TContext>
        where TContext : IContext
    {

        /// <summary>
        /// Creates a repository context 
        /// that can be used to perform data access against the repository.
        /// </summary>
        /// <param name="isTransactional">
        /// True if the context needs to be executed as a transaction.
        /// </param>
        /// <returns>
        /// A context instance.
        /// </returns>
        TContext CreateContext(bool isTransactional);

    }


}
