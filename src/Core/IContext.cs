using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.Core
{


    /// <summary>
    /// Provides data access methods for a repository.
    /// </summary>
    /// <remarks>
    /// When the context is disposed, any open resources (ex: connections, transactions) are closed.
    /// </remarks>
    public interface IContext
        : IDisposable
    {

        /// <summary>
        /// Commits a transaction if the <see cref="IContext"/> instance 
        /// was transactional.
        /// </summary>
        void CompleteTransaction();

    }


}
