using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using Csla.Core;
using System.Runtime.Serialization;
using Microsoft.Practices.Unity;


namespace CslaRepositoryTest.Core
{


    //InjectableCommandBase CLASS
    /// <summary>
    /// A <see cref="CommandBase"/> class that supports dependency injection.
    /// </summary>
    /// <remarks>
    /// Dependency injection will automatically occur when an instance of this type is 
    /// created by the server-side of the DataPortal (just before the DataPortal method 
    /// is called) and when an instance is deserialized.
    /// </remarks>
    [Serializable]
    public abstract class InjectableCommandBase
        : CommandBase
    {

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectableCommandBase"/> class.
        /// </summary>
        protected InjectableCommandBase()
        {
        }

        #endregion

        #region methods

        //EnsureDependency
        /// <summary>
        /// Ensures that the specified dependency exists (is not null).
        /// </summary>
        /// <typeparam name="TDependency">
        /// The type of the dependency.
        /// </typeparam>
        /// <param name="dependency">
        /// The dependency instance.
        /// </param>
        /// <returns>
        /// The same <paramref name="dependency"/> instance that was passed to the method.
        /// </returns>
        /// <exception cref="MissingDependencyInjectionException">
        /// When <paramref name="dependency"/> is null.
        /// </exception>
        protected TDependency EnsureDependency<TDependency>(TDependency dependency) where TDependency : class
        {
            if (dependency == null)
                throw new MissingDependencyInjectionException(this.GetType(), typeof(TDependency));
            return dependency;
        }

        #endregion

        #region overrides

        //CommandBase.DataPortal_OnDataPortalInvoke
        /// <summary>
        /// Overrides the <see cref="CommandBase"/> class's 
        /// <see cref="CommandBase.DataPortal_OnDataPortalInvoke"/> method 
        /// in order to invoke dependency injection after an instance has been created by the 
        /// server-side DataPortal.
        /// </summary>
        protected override void DataPortal_OnDataPortalInvoke(DataPortalEventArgs e)
        {
            //inject dependencies into instance created by server-side DataPortal
            this.Inject();
            //call base class
            base.DataPortal_OnDataPortalInvoke(e);
        }

        #endregion

        #region private methods

        //Inject
        private void Inject()
        {
            var type = this.GetType();
            Ioc.Container.BuildUp(type, this);
        }

        //OnDeserializedHandler
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "context",
            Justification = "This method is automatically called by the .NET serialization infrastructure.")]
        [OnDeserialized]
        private void OnDeserializedHandler(StreamingContext context)
        {
            //inject dependencies into the deserialized instance
            Inject();
        }

        #endregion

    }


}
