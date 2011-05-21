using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using System.IO;
using System.Runtime.InteropServices;

namespace neprostopleer.Cores
{
    class CoreDataProvider
    {
        private string _currentlyPlayed;
        public string currentlyPlayed
        {
            get
            {
                return _currentlyPlayed;
            }
            set
            {
                this.procUserClose(IntPtr.Zero);
                seekPosition = 0L;
                _currentlyPlayed = value;
                if (!String.IsNullOrWhiteSpace(value))
                    _currentlyPlayedStream = Program.streamer.GetStreamForId(value);
            }
        }

        private Stream _currentlyPlayedStream = null;
        public Stream currentlyPlayedStream
        {
            get
            {
                return _currentlyPlayedStream;
            }

        }

        private long seekPosition;

        public BASS_FILEPROCS bassStreamingProc { get; set; }

        public CoreDataProvider()
        {
            bassStreamingProc = new BASS_FILEPROCS(
                    new FILECLOSEPROC(procUserClose),
                    new FILELENPROC(procUserLength),
                    new FILEREADPROC(procUserRead),
                    new FILESEEKPROC(procUserSeek));
            seekPosition = 0L;
        }

        private void procUserClose(IntPtr user)
        {
            if (currentlyPlayedStream != null)
            {
                //currentlyPlayedStream.Close();
                _currentlyPlayed = null;
                seekPosition = 0L;
            }

        }

        private long procUserLength(IntPtr user)
        {
            if (currentlyPlayedStream == null)
                return 0L;
            else
                return currentlyPlayedStream.Length;
        }

        private int procUserRead(IntPtr buffer, int length, IntPtr user)
        {
            try
            {
                if (currentlyPlayedStream != null)
                {
                    currentlyPlayedStream.Seek(seekPosition, SeekOrigin.Begin);
                    
                    byte[] data = new byte[length];

                    int bytesread = currentlyPlayedStream.Read(data, 0, length);
                    seekPosition = currentlyPlayedStream.Position;

                    Marshal.Copy(data, 0, buffer, bytesread);
                    return bytesread;
                }
                else return 0;
            }
            catch (Exception e)
            {
                Program.logging.addToLog(e);
                return 0;
            }
        }

        private bool procUserSeek(long offset, IntPtr user)
        {
            if (currentlyPlayedStream != null)
            {
                if (offset < currentlyPlayedStream.Length)
                {
                    seekPosition = offset;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}
