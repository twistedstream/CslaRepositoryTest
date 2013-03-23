using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Practices.Unity;
using Rhino.Mocks;
using CslaRepositoryTest.Core;


namespace CslaRepositoryTest.Gui.Test
{


    //TestBase CLASS
    //- provides a base class for all unit tests in the project
    public abstract class TestBase
    {

        #region constructors

        protected TestBase()
        {
        }

        #endregion

        #region test event methods

        //TestFixtureSetUp
        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            //create test container 
            var container = new UnityContainer();

            //inject container into Ioc class
            Ioc.InjectContainer(container);
        }

        #endregion

    }


}
