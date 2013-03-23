using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.Gui.Views
{

    public interface IMessageBoxView
    {
        bool ShowYesNo(string message, string caption);
    }

}
