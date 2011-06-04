using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using neprostopleer.Entities.Misc;
using neprostopleer.Cores;

namespace neprostopleer
{
    public partial class PlayerWindow : CoreSnappingForm
    {

        public PlaylistWindow PlaylistWindow { get; set; }
        public PlayerWindow()
        {
            InitializeComponent();
            PlaylistWindow = new PlaylistWindow();
            NativeWindow natRef = new NativeWindow();
            natRef.AssignHandle(this.Handle);
            PlaylistWindow.Show(natRef);
            PlaylistWindow.Visible = false;
            Rectangle ScreenBounds = Screen.FromHandle(this.Handle).Bounds;
            Program.snappingManager.bounds[IntPtr.Zero] = ScreenBounds;
            trackBar1_ValueChanged(trackBar1, null);
        }

        public delegate void UpdateGUIStatusDelegate(PlayerProgressInformation info);

        public void UpdateGUIStatus(PlayerProgressInformation info)
        {
            this.mainArtistLabel.Text = info.artist;
            this.mainTrackLabel.Text = info.track;
            this.mainProgressLabel.Text = (info.currentPosition / 60) + ":" + ((""+(info.currentPosition % 60)).PadLeft(2,'0'));
            reflectPlayerStateInGUI(info.state);
        }

        private void reflectPlayerStateInGUI(PlayState playState)
        {
            if (playState.Equals(PlayState.PAUSED))
            {
                this.mainPlayPauseButton.ImageKey = "gtk-media-play-ltr.png";
            }
            else if (playState.Equals(PlayState.PLAYING))
            {
                this.mainPlayPauseButton.ImageKey = "gtk-media-pause.png";
            }
            else if (playState.Equals(PlayState.STOPPED))
            {
                //basically the same as paused
                this.mainPlayPauseButton.ImageKey = "gtk-media-play-ltr.png";
            }
        }

        private void mainPlayPauseButton_Click(object sender, EventArgs e)
        {
            //Program.provider.currentlyPlayed = "46639890738";
            //Program.player.PlayId("2682613W56");
            bool playing = Program.player.PlayPauseToggle();
            Button clickedButton = (Button)sender;
            if (playing)
            {
                clickedButton.ImageKey = "gtk-media-pause.png";
            }
            else
            {
                clickedButton.ImageKey = "gtk-media-play-ltr.png";
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (Program.player != null)
            {
                int value = ((TrackBar)sender).Value;
                int max = ((TrackBar)sender).Maximum;
                double percentValue = (value + 0.0d) / max;
                Program.player.Volume = percentValue;
            }
        }

        private void mainPlaylistButton_Click(object sender, EventArgs e)
        {
            // TODO: Show should reference owner!
            PlaylistWindow.Visible = !PlaylistWindow.Visible;
            
            return;
            Program.player.PlayId("2682613W56");
            
            // use bcrypt
        }

        private void mainSearchButton_Click(object sender, EventArgs e)
        {
            Program.settings["pp_password"] = "LOL";
            //Program.storage.InitializeDatabaseAccess();
        }

        private void mainNextButton_Click(object sender, EventArgs e)
        {
            Program.prostopleerWebServices.InitializeWebServices();
        }

        private void mainStopButton_Click(object sender, EventArgs e)
        {
            Program.player.Stop();
        }

        private void PlayerWindow_Load(object sender, EventArgs e)
        {

        }

        private void mainPrevButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
