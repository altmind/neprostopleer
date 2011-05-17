using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace neprostopleer
{
    public partial class PlayerWindow : Form
    {
        public PlayerWindow()
        {
            InitializeComponent();
            Program.playerWindow = this;
        }

        private void mainPlayPauseButton_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //int value = ((TrackBar)sender).Value;
            //int max = ((TrackBar)sender).Maximum;
            //double percentValue = (value+0.0d) / max;
            //Program.core.setVolume(percentValue);
        }

        private void mainPlaylistButton_Click(object sender, EventArgs e)
        {
            // use bcrypt
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");
            ManagementObjectCollection objMOC;

            objMOC = objMOS.Get();
            string serial=null;
            string user = null;
            foreach (ManagementObject objMO in objMOC)
            {
                serial = objMO["SerialNumber"].ToString();
            }
            

            objMOS = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            objMOC = objMOS.Get();

            foreach (ManagementObject objMO in objMOC)
            {
                user = objMO["UserName"].ToString();
            }
            MessageBox.Show(serial+" "+user);

        }

        private void mainSearchButton_Click(object sender, EventArgs e)
        {
            Program.storage.InitializeDatabaseAccess();
        }

        private void mainNextButton_Click(object sender, EventArgs e)
        {
            Program.prostopleerWebServices.InitializeWebServices();
        }
    }
}
