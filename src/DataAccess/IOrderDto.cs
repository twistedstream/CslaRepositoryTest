using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.DataAccess
{


    //DTO for order entities
    public interface IOrderDto
    {
        int Id { get; set;  }
        string Customer { get; set; }
        DateTime Date { get; set; }
        decimal ShippingCost { get; set; }
        byte[] Timestamp { get; set; }
        IEnumerable<ILineItemDto> LineItems { get; }
    }


}
