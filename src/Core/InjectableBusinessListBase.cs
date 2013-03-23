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


    //InjectableBusinessListBase CLASS
    /// <summary>
    /// A <see cref="BusinessListBase{T,C}"/> class that supports dependency injection.
    /// </summary>
    /// <typeparam name="TCollection">
    /// The type of the business object being defined.
    /// </typeparam>
    /// <typeparam name="TItem">
    /// The type of the child objects contained in the list.
    /// </typeparam>
    /// <remarks>
    /// Dependency injection will automatically occur when an instance of this type is 
    /// created by the server-side of the DataPortal (just before the DataPortal method 
    /// is called) and when an instance is deserialized.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "The InjectableBusinessListBase class follows the CSLA.NET naming convension.")]
    [Serializable]
    public abstract class InjectableBusinessListBase<TCollection, TItem>
        : BusinessListBase<TCollection, TItem>
        where TCollection : BusinessListBase<TCollection, TItem>
        where TItem : IEditableBusinessObject
    {

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectableBusinessListBase{T,C}"/> class.
        /// </summary>
        protected InjectableBusinessListBase()
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

        //BusinessBase.DataPortal_OnDataPortalInvoke
        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.DataPortal_OnDataPortalInvoke"/> method 
        /// in order to invoke dependency injection after an instance has been created by the 
        /// server-side DataPortal.
        /// </summary>
        protected override void DataPortal_OnDataPortalInvoke(DataPortalEventArgs e)
        {
            //inject dependencies into instance created by server-side DataPortal
            Inject();
            //call base class
            base.DataPortal_OnDataPortalInvoke(e);
        }

        //BusinessBase.Child_OnDataPortalInvoke
        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.Child_OnDataPortalInvoke"/> method 
        /// in order to invoke dependency injection after an instance has been created by the 
        /// server-side DataPortal.
        /// </summary>
        protected override void Child_OnDataPortalInvoke(DataPortalEventArgs e)
        {
            //inject dependencies into instance created by server-side DataPortal
            Inject();
            //call base class
            base.Child_OnDataPortalInvoke(e);
        }

        //BusinessBase.OnDeserialized
        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.OnDeserialized"/> method 
        /// in order to invoke dependency injection after an instance has been deserialized.
        /// </summary>
        protected override void OnDeserialized(StreamingContext context)
        {
            //inject dependencies into the deserialized instance
            Inject();
            //call base class
            base.OnDeserialized(context);
        }

        #endregion

        #region private methods

        //Inject
        private void Inject()
        {
            var type = this.GetType();
            Ioc.Container.BuildUp(type, this);
        }

        #endregion

    }


}
