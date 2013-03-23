using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.Core
{


    //IIocContainerConfigFileProvider
    /// <summary>
    /// Provides an <see cref="IIocContainerConfigurator"/> instance with its needed configuration file.
    /// </summary>
    public interface IIocContainerConfigFileProvider
    {

        #region properties

        //BuildConfigFilePath
        /// <summary>
        /// Gets the full file path to the configuration file.
        /// </summary>
        string ConfigFilePath { get; }

        #endregion

    }


}
