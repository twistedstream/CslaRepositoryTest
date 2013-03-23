using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Reflection;
using System.Configuration;
using System.Globalization;


namespace CslaRepositoryTest.Core
{


    //IocContainerConfigFileProvider CLASS
    /// <summary>
    /// The default implementation of the <see cref="IIocContainerConfigFileProvider"/> interface.
    /// </summary>
    public class IocContainerConfigFileProvider
        : IIocContainerConfigFileProvider
    {

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IocContainerConfigFileProvider"/> class.
        /// </summary>
        /// <param name="configFilePathAppSettingKey">
        /// The appSetting key in the host application's .config file that contains the path to the IOC container configuration file.
        /// </param>
        public IocContainerConfigFileProvider(string configFilePathAppSettingKey)
        {
            //validate params
            if (string.IsNullOrEmpty(configFilePathAppSettingKey))
            {
                throw new ArgumentNullException("configFilePathAppSettingKey");
            }
            //get path from app.config app setting
            this.ConfigFilePath = ConfigurationManager.AppSettings[configFilePathAppSettingKey];
            //make sure appSetting exists
            if (string.IsNullOrEmpty(this.ConfigFilePath))
            {
                throw new ConfigurationErrorsException(
                    string.Format(CultureInfo.CurrentCulture, "The required appSetting key '{0}' (that contains the path to the IOC Container configuration file) is missing from the host applicaiton's configuration file.",
                        configFilePathAppSettingKey));
            }
        }

        #endregion

        #region IIocContainerConfigFileProvider implementation

        //ConfigFilePath
        /// <summary>
        /// Implements the <see cref="IIocContainerConfigFileProvider"/> interface's 
        /// <see cref="IIocContainerConfigFileProvider.ConfigFilePath"/> property.
        /// </summary>
        public string ConfigFilePath { get; private set; }

        #endregion

    }


}
