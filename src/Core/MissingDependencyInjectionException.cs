using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.ObjectModel;
using System.Globalization;


namespace CslaRepositoryTest.Core
{


    //MissingDependencyInjectionException CLASS
    /// <summary>
    /// Represents the exception that is thrown when a type or instance that requires 
    /// an injected dependency does not have a dependency instance.
    /// </summary>
    [Serializable]
    public class MissingDependencyInjectionException 
        : Exception
    {

        #region constructors

        //.ctor()
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingDependencyInjectionException"/> class.
        /// </summary>
        public MissingDependencyInjectionException()
        {
        }

        //.ctor(string)
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingDependencyInjectionException"/> class 
        /// with the specified error message.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public MissingDependencyInjectionException(string message)
            : base(message)
        {
        }

        //.ctor(string,Exception)
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingDependencyInjectionException"/> class 
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        public MissingDependencyInjectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        //.ctor(Type,Type)
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingDependencyInjectionException"/> class 
        /// with the type of the parent and the missing dependency.
        /// </summary>
        /// <param name="parentType">
        /// The type that depends on the dependency.
        /// </param>
        /// <param name="dependencyType">
        /// The type of the missing dependency.
        /// </param>
        public MissingDependencyInjectionException(Type parentType, Type dependencyType)
            : this(MissingDependencyInjectionException.MessageFromTypes(parentType, dependencyType))
        {
            //validate params
            if (parentType == null)
            {
                throw new ArgumentNullException("parentType");
            }
            if (dependencyType == null)
            {
                throw new ArgumentNullException("dependencyType");
            }
        }

        //.ctor(SerializationInfo,StreamingContext)
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingDependencyInjectionException"/> class 
        /// with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the serialized 
        /// object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual 
        /// information about the source or destination. 
        /// </param>
        protected MissingDependencyInjectionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region private methods

        //MessageFromTypes
        private static string MessageFromTypes(Type parentType, Type dependencyType)
        {
            var message = "";
            if (parentType != null && dependencyType != null)
            {
                message = string.Format(CultureInfo.CurrentCulture, "An instance of type '{0}' is missing a dependency instance of type '{1}'.",
                    parentType.FullName,
                    dependencyType.FullName);
            }
            return message;
        }

        #endregion

    }


}
