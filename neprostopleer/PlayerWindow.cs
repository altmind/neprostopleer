using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace neprostopleer
{
    public partial class PlayerWindow : Form
    {
        public PlayerWindow()
        {
            InitializeComponent();
            Program.core = new Core();
            Program.playerWindow = this;
            Program.core.InitializeSound();
        }

        private void mainPlayPauseButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Program.core.PlayUrl(@"http://altio.us/files/shapeshifter-southern_lights-feat_kp.mp3");
                Program.core.PlayUrl(@"http://192.168.100.2/ThePretenders-10BreakUpTheConcrete.mp3");
                
            }
            catch (Exception ex)
            {
                Program.core.loggingCore.processException(ex);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int value = ((TrackBar)sender).Value;
            int max = ((TrackBar)sender).Maximum;
            double percentValue = (value+0.0d) / max;
            Program.core.setVolume(percentValue);
        }
    }
}
