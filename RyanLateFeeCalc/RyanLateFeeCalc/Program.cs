using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RyanLateFeeCalc
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

            // Initializes the Menu by default
            Application.Run(new frmMenu());

            // For testing purposes
            //Application.Run(new frmLateFilms());
            //Application.Run(new frmNew());
            //Application.Run(new frmLibrary());
            //Application.Run(new frmKids());
        }
    }
}
