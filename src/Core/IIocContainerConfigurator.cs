using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;


namespace CslaRepositoryTest.Core
{


    //IIocContainerConfigurator INTERFACE
    /// <summary>
    /// Configures an <see cref="IUnityContainer"/>.
    /// </summary>
    public interface IIocContainerConfigurator
    {

        #region methods

        //Configure
        /// <summary>
        /// Configures the specified container using configuration information found in the 
        /// configuration file.
        /// </summary>
        /// <param name="container">
        /// The <see cref="IUnityContainer"/> to configure.
        /// </param>
        void Configure(IUnityContainer container);

        #endregion

    }


}
