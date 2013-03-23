using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.DataAccess
{


    //DTO for order summary data
    public interface IOrderInfoDto
    {
        int Id { get; set; }
        string Customer { get; set; }
        DateTime Date { get; set; }
    }


}
