using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PianoForte.View;
using System.IO;
namespace PianoForte
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StreamWriter log = new StreamWriter("log.txt");
            log.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());            
        }
    }
}
