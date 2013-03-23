using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.DataAccess
{


    //DTO for order line item entities
    public interface ILineItemDto
    {
        int Id { get; set; }
        int OrderId { get; set; }
        string ProductName { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
        byte[] Timestamp { get; set; }
    }


}
