﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using neprostopleer.Cores;
using neprostopleer.Cores.DAO;
using neprostopleer.Natives;
using System.Runtime.InteropServices;

namespace neprostopleer
{
    static class Program
    {
        //public static Core core = null;
        public static CoreSettings settings = new CoreSettings();
        public static PlayerWindow playerWindow = null;
        public static LogWindow logWindow = null;
        public static CoreProstopleerWebServices prostopleerWebServices = new CoreProstopleerWebServices();
        public static CoreStreamer streamer = new CoreStreamer();
        // should be localized in coreplayer
        //public static CoreDataProvider dataProvider = new CoreDataProvider();
        public static CoreLogging logging = new CoreLogging();
        public static CoreStorageAccess storage = new CoreStorageAccess();
        public static CoreJSONBinder binder = new CoreJSONBinder();

        //public static CoreDataProvider provider = new CoreDataProvider();
        public static CorePlayer player;

        public static DAOs daos = new DAOs();

        public static CoreSnappingManager snappingManager = new CoreSnappingManager();
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            performGlobalInitialization();
            Program.playerWindow = new PlayerWindow();
            Program.player = new CorePlayer();
            Application.Run(Program.playerWindow);
        }

        private static void performGlobalInitialization()
        {
            performUIInitialization();
        }

        private static void performUIInitialization()
        {
            // Show window contents while dragging: essential for snapping
            if (!Natives.Natives.SystemParametersInfo(SPI.SPI_SETDRAGFULLWINDOWS, 1, null, 0))
            {
                Program.logging.addToLog("SystemParametersInfo SPI_SETDRAGFULLWINDOWS returned error. Win32Error:" + Marshal.GetLastWin32Error() + " HRESULT: " + Marshal.GetHRForLastWin32Error());
            }
        }
    }
}
