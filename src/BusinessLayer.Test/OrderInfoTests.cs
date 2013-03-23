using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using CslaRepositoryTest.DataAccess;
using NUnit.Framework.SyntaxHelpers;
using CslaRepositoryTest.Core;
using System.Linq.Expressions;


namespace CslaRepositoryTest.BusinessLayer.Test
{


    [TestFixture]
    public class OrderInfoTests
        : TestBase
    {

        #region tests

        [Test]
        public void OrderInfoCollection_Fetch_returns_expected_data()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                //mock data
                var orderData1 = mocks.StrictMock<IOrderInfoDto>();
                Expect.Call(orderData1.Id).Return(100).Repeat.Any();
                Expect.Call(orderData1.Customer).Return("Bob").Repeat.Any();
                Expect.Call(orderData1.Date).Return(DateTime.Parse("1/1/2008")).Repeat.Any();
                var orderData2 = mocks.StrictMock<IOrderInfoDto>();
                Expect.Call(orderData2.Id).Return(101).Repeat.Any();
                Expect.Call(orderData2.Customer).Return("Jim").Repeat.Any();
                Expect.Call(orderData2.Date).Return(DateTime.Parse("2/1/2008")).Repeat.Any();
                //mock read context
                IOrderContext readContext = mocks.StrictMock<IOrderContext>();
                Expect.Call(readContext.FetchInfoList()).Return(new[] { orderData1, orderData2 });
                readContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(false)).Return(readContext);
            }
            using (mocks.Playback())
            {
                //fetch collection
                IOrderFactory factory = new OrderFactory();
                var collection = factory.FetchInfoList();
                //test count
                Assert.That(collection.Count, Is.EqualTo(2));
                //test state of items in collection 
                IOrderInfo item;
                item = collection[0];
                Assert.That(item.Id, Is.EqualTo(100));
                Assert.That(item.Customer, Is.EqualTo("Bob"));
                Assert.That(item.Date, Is.EqualTo(DateTime.Parse("1/1/2008")));
                item = collection[1];
                Assert.That(item.Id, Is.EqualTo(101));
                Assert.That(item.Customer, Is.EqualTo("Jim"));
                Assert.That(item.Date, Is.EqualTo(DateTime.Parse("2/1/2008")));
            }
        }

        #endregion

    }


}
