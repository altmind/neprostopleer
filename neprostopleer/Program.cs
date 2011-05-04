using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace neprostopleer
{
    static class Program
    {
        public static Core core = null;
        public static PlayerWindow playerWindow = null;
        public static LogWindow logWindow = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PlayerWindow());
        }
    }
}
