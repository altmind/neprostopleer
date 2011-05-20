using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;
using neprostopleer.Entities.DB;
using System.Threading;
using System.Net;
using neprostopleer.Util;

namespace neprostopleer.Cores
{
    class CoreStreamer
    {

        private IDictionary<string, Stream> currentlyFetching;


        public CoreStreamer()
        {

            currentlyFetching = new Dictionary<string, Stream>();
        }


        public Stream GetStreamForId(string id)
        {
            return GetStreamForId(id, false);
        }

        public Stream GetStreamForId(string id, bool prefetchOnly)
        {
            Track t = Program.daos.trackDAO.getTrackById(id);

            if (t != null && "DOWNLOADED".Equals(t.state) && File.Exists(t.disklocation))
            {
                if (prefetchOnly)
                    return null;
                else
                    return new FileStream(t.disklocation, FileMode.Open);
            }
            if (t != null && "DOWNLOADING".Equals(t.state) && currentlyFetching.ContainsKey(id))
            {
                if (prefetchOnly)
                    return null;
                else
                    return currentlyFetching[id];
            }
            else
            {
                return CreateMemoryStreamForUri(id, Program.prostopleerWebServices.getUriForTrackId(id));
            }
        }

        private Stream CreateMemoryStreamForUri(string id, Uri uri)
        {
            /*
             * TODO: @altmind: replace this with TPL. Or maybe not? This task is not CPU-bound.
             */
            AutoResetEvent evt = new AutoResetEvent(false);
            Thread t = new Thread(new ParameterizedThreadStart(ThreadedDownloader));
            t.Start(new Tuple<string, Uri, AutoResetEvent>(id, uri, evt));
            evt.WaitOne();
            return currentlyFetching[id];
        }

        void ThreadedDownloader(object o)
        {
            Tuple<string, Uri, AutoResetEvent> val = (Tuple<string, Uri, AutoResetEvent>)o;
            string id = val.Item1;
            Uri uri = val.Item2;
            AutoResetEvent evt = val.Item3;

            MemoryStream outStream = new MemoryStream();

            currentlyFetching[id] = outStream;
            evt.Set();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            Stream stream = req.GetResponse().GetResponseStream();

            //long contentLength = req.GetResponse().ContentLength;

            try
            {
                byte[] data = new byte[4096];
                int read;
                while ((read = stream.Read(data, 0, data.Length)) > 0)
                {
                    outStream.Write(data, 0, read);
                }

                stream.Close();
                WriteStreamForIDToDisk(id);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

        }

        private string GetFilenameForTrackID(string id)
        {
            return Path.Combine(Path.GetTempPath(), id + ".mp3");
        }
        private void WriteStreamForIDToDisk(string id)
        {
            if (currentlyFetching.ContainsKey(id))
            {
                MemoryStream stream = (MemoryStream)currentlyFetching[id];

                String fileName=GetFilenameForTrackID(id);

                
                using (FileStream fileStream = File.OpenWrite(fileName))
                {

                    //byte[] buffer = new byte[4096];
                    //int len;
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                    //while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    //{
                    //    fileStream.Write(buffer, 0, len);
                    //}    
                }
                stream.Close();

                
                Track trackRecord = new Track(id,"DOWNLOADED",fileName,DateTime.Now);
                Program.daos.trackDAO.updateTrack(trackRecord);

                currentlyFetching.Remove(id);
            }
            else
            {
                Program.logging.addToLog("Stream downloading thread signaled that it is finished downloading and stream is ready to be written to disk, but we cannot find stream for id " + id + " in list of being currently downloaded.");
            }
        }
    }
}
