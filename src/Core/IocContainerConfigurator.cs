using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Globalization;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;


namespace CslaRepositoryTest.Core
{


    //IocContainerConfigurator CLASS
    /// <summary>
    /// The default implementation of the <see cref="IIocContainerConfigurator"/> interface.
    /// </summary>
    public class IocContainerConfigurator
        : IIocContainerConfigurator
    {

        #region private fields

        private IIocContainerConfigFileProvider configFileProvider;
        private string configSectionName;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IocContainerConfigurator"/> class.
        /// </summary>
        /// <param name="configFileProvider">
        /// The <see cref="IIocContainerConfigFileProvider"/> instance used to get the configuration file.
        /// </param>
        /// <param name="configSectionName">
        /// The name of the section containing the Unity configuration data.
        /// </param>
        public IocContainerConfigurator(IIocContainerConfigFileProvider configFileProvider, string configSectionName)
        {
            //validate params
            if (configFileProvider == null)
            {
                throw new ArgumentNullException("configFileProvider");
            }
            if (configSectionName == null)
            {
                throw new ArgumentNullException("configSectionName");
            }
            //populate
            this.configFileProvider = configFileProvider;
            this.configSectionName = configSectionName;
        }

        #endregion

        #region IIocContainerConfigurator implementation

        //Configure
        /// <summary>
        /// Implements the <see cref="IIocContainerConfigurator"/> interface's 
        /// <see cref="IIocContainerConfigurator.Configure"/> method.
        /// </summary>
        public void Configure(IUnityContainer container)
        {
            //open config file
            var map = new ExeConfigurationFileMap
            {
                ExeConfigFilename = this.configFileProvider.ConfigFilePath
            };
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            if (!config.HasFile)
            {
                throw new ConfigurationErrorsException(
                    string.Format(CultureInfo.CurrentCulture, "Expected configuration file not found at path '{0}'.",
                        config.FilePath));
            }
            //open config section
            var section = (UnityConfigurationSection)config.GetSection(this.configSectionName);
            if (section == null)
            {
                throw new ConfigurationErrorsException(
                    string.Format(CultureInfo.CurrentCulture, "Required section '{0}' not found in configuration file at path '{1}'.",
                        this.configSectionName,
                        config.FilePath));
            }
            //configure
            section.Containers.Default.Configure(container);
        }

        #endregion

    }


}
