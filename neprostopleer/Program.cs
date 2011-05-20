using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using neprostopleer.Cores;
using neprostopleer.Cores.DAO;

namespace neprostopleer
{
    static class Program
    {
        //public static Core core = null;
        public static PlayerWindow playerWindow = null;
        public static LogWindow logWindow = null;
        public static CoreProstopleerWebServices prostopleerWebServices = new CoreProstopleerWebServices();
        public static CoreStreamer streamer = new CoreStreamer();
        public static CoreDataProvider dataProvider = new CoreDataProvider();
        public static CoreLogging logging = new CoreLogging();
        public static CoreStorageAccess storage = new CoreStorageAccess();
        public static CoreJSONBinder binder = new CoreJSONBinder();

        public static DAOs daos = new DAOs();
        

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
