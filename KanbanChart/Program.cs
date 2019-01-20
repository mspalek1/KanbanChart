using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Demos;

namespace KanbanChart
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
            //Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new WF());
           //var f = new WF();
           //f.Show();
        }
    }
}
