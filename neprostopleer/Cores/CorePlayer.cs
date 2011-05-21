﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using System.IO;
using System.Windows.Forms;
using Un4seen.Bass.AddOn.Tags;
using neprostopleer.Entities.Misc;

namespace neprostopleer.Cores
{
    class CorePlayer : IDisposable
    {
        public bool SoundInitialized { get; set; }
        private Stream CurrentStream { get; set; }
        private CoreDataProvider DataProvider { get; set; }
        private int BassStream { get; set; }
        private BASSTimer BassTimer= null;

        //private int BassChannel { get; set; }
        public CorePlayer()
        {
            InitializeDataProvider();
            InitializeSound();
        }

        private void InitializeDataProvider()
        {
            if (DataProvider == null)
                DataProvider = new CoreDataProvider();
        }

        public void InitializeSound()
        {
            if (SoundInitialized != true)
            {
                if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Program.playerWindow.Handle))
                {
                    BassTimer = new BASSTimer(500);
                    BassTimer.Tick += new EventHandler(BassTimer_Tick);
                    SoundInitialized = true;
                }
                else
                {
                    SoundInitialized = false;
                    BASSError err = Bass.BASS_ErrorGetCode();
                    throw new Exception("Cannot init bass: " + err.ToString());
                }
            }
        }

        void BassTimer_Tick(object sender, EventArgs e)
        {
            if (Bass.BASS_ChannelIsActive(BassStream) != BASSActive.BASS_ACTIVE_PLAYING)
            {
                BassTimer.Stop();
            }
            else
            {
                Program.playerWindow.Invoke(new neprostopleer.PlayerWindow.UpdateGUIStatusDelegate(UpdateGUIStatus),new object[] {new PlayerProgressInformation()});
            }
        }

        public void PlayId(string id)
        {
            if (SoundInitialized)
            {
                DataProvider.currentlyPlayed = id;
                BassStream = Bass.BASS_StreamCreateFileUser(BASSStreamSystem.STREAMFILE_NOBUFFER, BASSFlag.BASS_STREAM_AUTOFREE, DataProvider.bassStreamingProc, IntPtr.Zero);
                if (BassStream == 0)
                {
                    BASSError err = Bass.BASS_ErrorGetCode();

                    throw new Exception("Cannot create stream: " + err.ToString());
                }

                Bass.BASS_ChannelPlay(BassStream, false);
            }
        }



        public void Dispose()
        {
            if (SoundInitialized)
            {
                if (BassStream!=0)
                    Bass.BASS_StreamFree(BassStream);
                Bass.BASS_Free();
            }
        }

#pragma warning disable 0465
        protected void Finalize()
        {
            Dispose();
        }
#pragma warning restore 0465

        public double Volume
        {
            get
            {
                return Bass.BASS_GetVolume();
            }
            set
            {
                Bass.BASS_SetVolume((float)value);
            }
        }

        public bool PlayPauseToggle()
        {

            if (!SoundInitialized || BassStream == 0) return false;
            if (Bass.BASS_ChannelIsActive(BassStream)==BASSActive.BASS_ACTIVE_PAUSED)
            {
                if (!Bass.BASS_ChannelPlay(BassStream, false))
                {
                    throw new Exception("Cannot resume playback: " + Bass.BASS_ErrorGetCode().ToString());
                }
                return true;
            }
            else
            {
                if (!Bass.BASS_ChannelPause(BassStream))
                {
                    throw new Exception("Cannot pause playback: " + Bass.BASS_ErrorGetCode().ToString());
                }
                return false;
            }
        }

        public void Stop()
        {
            if (!SoundInitialized || BassStream == 0) return;
            if (!Bass.BASS_ChannelStop(BassStream))
            {
                throw new Exception("Cannot stop playback: " + Bass.BASS_ErrorGetCode().ToString());
            }
            else
            {
                Bass.BASS_StreamFree(BassStream);
                BassStream = 0;
            }
        }


        private void MetaSync(int handle, int channel, int data, IntPtr user)
        {
            //Bass.BASS_ChannelGetTags(channel, BASSTag.BASS_TAG_META);
        }
    }
}