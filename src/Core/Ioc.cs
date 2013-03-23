using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;


namespace CslaRepositoryTest.Core
{


    //Ioc CLASS
    /// <summary>
    /// Provides access to the IOC Container shared by all DataScope Select applications.
    /// </summary>
    public static class Ioc
    {

        #region private fields

        private static readonly object typeLock = new object();
        private static IIocContainerConfigurator configurator;

        #endregion

        #region properties

        //Container
        private static IUnityContainer container;
        /// <summary>
        /// Gets the Singleton <see cref="IUnityContainer"/> used by all DataScope Select applications.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                //create and configure container if one does not yet exist
                if (Ioc.container == null)
                {
                    lock (Ioc.typeLock)
                    {
                        if (Ioc.container == null)
                        {
                            //get configurator
                            if (Ioc.configurator == null)
                            {
                                //create default configurator
                                var configFilePathProvider = new IocContainerConfigFileProvider("unityConfigFilePath");
                                Ioc.configurator = new IocContainerConfigurator(configFilePathProvider, "unity");
                            }
                            //create container
                            Ioc.container = new UnityContainer();
                            //configure
                            Ioc.configurator.Configure(Ioc.container);
                        }
                    }
                }
                return Ioc.container;
            }
        }

        #endregion

        #region methods

        //InjectContainer
        /// <summary>
        /// Injects the IOC Container instance into the <see cref="Ioc"/> class.
        /// </summary>
        /// <param name="container">
        /// The <see cref="IUnityContainer"/> to inject.
        /// </param>
        /// <remarks>
        /// This method is primarily used for unit testing purposes.
        /// </remarks>
        public static void InjectContainer(IUnityContainer container)
        {
            lock (Ioc.typeLock)
            {
                Ioc.container = container;
            }
        }

        //InjectConfigurator
        /// <summary>
        /// Injects the IOC Container configurator instance into the <see cref="Ioc"/> class.
        /// </summary>
        /// <param name="configurator">
        /// The <see cref="IIocContainerConfigurator"/> to inject.
        /// </param>
        /// <remarks>
        /// This method is primarily used for unit testing purposes.
        /// </remarks>
        public static void InjectConfigurator(IIocContainerConfigurator configurator)
        {
            lock (Ioc.typeLock)
            {
                Ioc.configurator = configurator;
            }
        }

        #endregion

    }


}
