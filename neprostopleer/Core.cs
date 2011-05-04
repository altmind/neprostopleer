using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;

namespace neprostopleer
{
    class Core
    {
        private bool initialized = false;
        private int stream = 0;
        private float volume = 0.33f;
        private MemoryStream playFromMemoryStream;
        private BASS_FILEPROCS myStreamCreateUser;
        private long contentLength;
        private long seekpos = 0;

        public void addToLog(Exception e)
        {
            addToLog(e.ToString(), true);
        }

        public void addToLog(String s)
        {
            addToLog(s,true);
        }

        public void addToLog(String s, bool showWindow)
        {
            if (Program.logWindow == null)
                Program.logWindow = new LogWindow();
            Program.logWindow.Text += s + Environment.NewLine;
            if (showWindow)
            {
                Program.logWindow.Show();
            }
        }

        public void processException(Exception e)
        {
            addToLog(e.Message,true);
        }

        private void FillMemoryStream()
        {
            try
            {
                //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://altio.us/files/shapeshifter-southern_lights-feat_kp.mp3");
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://192.168.100.2/ThePretenders-10BreakUpTheConcrete.mp3");
            
                this.contentLength = req.GetResponse().ContentLength;
                Stream stream = req.GetResponse().GetResponseStream();

                byte[] data = new byte[4096];
                int read;
                while ((read = stream.Read(data, 0, data.Length)) > 0)
                {
                    playFromMemoryStream.Write(data, 0, read);
                }
            }
            catch (Exception ex)
            {
                Program.core.addToLog(ex);
            }
        }

        public void PlayUrl(string url)
        {
            if (initialized)
            {
                
                //stream = Bass.BASS_StreamCreateFileUser(
                stream = Bass.BASS_StreamCreateFileUser(BASSStreamSystem.STREAMFILE_NOBUFFER, BASSFlag.BASS_STREAM_AUTOFREE , myStreamCreateUser, IntPtr.Zero);
                //stream = Bass.BASS_StreamCreateURL(url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
                if (stream != 0)
                    Bass.BASS_ChannelPlay(stream, false);
            }
            else
                throw new SoundException("Cannot play file");

        }
        public void InitializeSound()
        {
            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Program.playerWindow.Handle))
            {
                initialized = true;
                Thread t = new Thread(new ThreadStart(FillMemoryStream));
                t.Start();
                
                playFromMemoryStream = new MemoryStream();
                playFromMemoryStream.Seek(0, SeekOrigin.Begin);
                myStreamCreateUser = new BASS_FILEPROCS(
                    new FILECLOSEPROC(MyFileProcUserClose),
                    new FILELENPROC(MyFileProcUserLength),
                    new FILEREADPROC(MyFileProcUserRead),
                    new FILESEEKPROC(MyFileProcUserSeek));
            }
            else
                throw new SoundException("Cannot initialize sound");
        }


        private void MyFileProcUserClose(IntPtr user)
        {
            //if (_fs == null)
            //    return;

            //_fs.Close();

            //this.Invoke(new UpdateMessageDelegate(UpdateMessageDisplay), new object[] { "FileClose" + Environment.NewLine });
        }

        private long MyFileProcUserLength(IntPtr user)
        {
            return this.contentLength;
        }

        private int MyFileProcUserRead(IntPtr buffer, int length, IntPtr user)
        {
            //if (_fs == null)
            //    return 0;
            if (!successiveCalls)
            {
                playFromMemoryStream.Seek(0, SeekOrigin.Begin);
                successiveCalls = true;
            }
            try
            {
                // at first we need to create a byte[] with the size of the requested length
                byte[] data = new byte[length];
                // read the file into data
                //playFromMemoryStream.Seek(seekpos, SeekOrigin.Begin);
                int bytesread = playFromMemoryStream.Read(data, 0, length);
                    //_fs.Read(data, 0, length);

                //this.Invoke(new UpdateMessageDelegate(UpdateMessageDisplay), new object[] { "__READ: " + buffer+", "+ length + Environment.NewLine });

                //this.Invoke(new UpdateMessageDelegate(UpdateMessageDisplay), new object[] { "BytesRead: " + bytesread.ToString() + Environment.NewLine });

                Marshal.Copy(data, 0, buffer, bytesread);

                return bytesread;
            }
            catch { return 0; }
        }

        private bool MyFileProcUserSeek(long offset, IntPtr user)
        {
            try
            {
                playFromMemoryStream.Seek(offset, SeekOrigin.Begin);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            //if (_fs == null)
            //    return false;

            //try
            //{
            //    long pos = _fs.seek(offset, seekorigin.begin);

            //    this.invoke(new updatemessagedelegate(updatemessagedisplay), new object[] { "seekpos: " + pos.tostring() + environment.newline });

            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public void UninitilizeSound()
        {
            if (stream != 0)
                Bass.BASS_StreamFree(stream);
            if (initialized)
                Bass.BASS_Free();
        }

        internal void setVolume(double percentValue)
        {
            volume = (float)percentValue;
            Bass.BASS_SetVolume(volume);
        }

        public bool successiveCalls;
    }
}
