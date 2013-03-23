using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CslaRepositoryTest.Core;
using CslaRepositoryTest.Gui.Views;

namespace CslaRepositoryTest.Gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var viewFactory = Ioc.Container.Resolve<IViewFactory>();
            var startupView = viewFactory.CreateStartupView();
            startupView.Run();
        }
    }
}
