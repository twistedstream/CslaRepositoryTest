namespace CslaRepositoryTest.DataAccess.SqlServerRepository
{


    //NOTE: using statements need to live inside the namespace block due to a bug with the 
    //      DBML designer in VS2008 SP1
    //      (see: http://blog.unidev.com/index.php/2008/09/02/the-custom-tool-mslinqtosqlgenerator-failed-unspecified-error/)
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Linq;


    partial class Order
        : IOrderDto
    {

        #region IOrderDto Members

        byte[] IOrderDto.Timestamp
        {
            get
            {
                return this.Timestamp.ToArray();
            }
            set
            {
                this.Timestamp = new Binary(value);
            }
        }

        IEnumerable<ILineItemDto> IOrderDto.LineItems
        {
            get
            {
                return this.LineItems.Cast<ILineItemDto>();
            }
        }

        #endregion

    }


    partial class LineItem
        : ILineItemDto
    {

        #region ILineItemDto Memebers

        byte[] ILineItemDto.Timestamp
        {
            get
            {
                return this.Timestamp.ToArray();
            }
            set
            {
                this.Timestamp = new Binary(value);
            }
        }

        #endregion

    }


}
