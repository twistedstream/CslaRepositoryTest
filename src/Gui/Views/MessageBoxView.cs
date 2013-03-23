using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CslaRepositoryTest.Gui.Views
{


    public class MessageBoxView
        : IMessageBoxView
    {

        #region IMessageBoxView members

        public bool ShowYesNo(string message, string caption)
        {
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        #endregion

    }


}
