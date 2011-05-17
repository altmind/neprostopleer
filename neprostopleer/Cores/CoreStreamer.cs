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
            Track t = null;
            using (SQLiteCommand fetchcommand = Program.storage.GetCommand("SELECT ID, STATE, DISKLOCATION, FETCHTIME FROM TRACKS"))
            {
                using (SQLiteDataReader reader = fetchcommand.ExecuteReader())
                {
                    Int64 data_fetchtime = reader.GetInt64(reader.GetOrdinal("FETCHTIME"));
                    string data_id = reader.GetString(reader.GetOrdinal("ID"));
                    string data_state = reader.GetString(reader.GetOrdinal("STATE"));
                    string data_disklocation = reader.GetString(reader.GetOrdinal("DISKLOCATION"));
                    t = new Track(data_id, data_state, data_disklocation, data_fetchtime);
                }
            }
            if (t != null && "DOWNLOADED".Equals(t.state) && File.Exists(t.disklocation))
            {
                return new FileStream(t.disklocation, FileMode.Open);
            }
            if (t != null && "DOWNLOADING".Equals(t.state) && currentlyFetching.ContainsKey(id))
            {
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
            t.Start(new Tuple<string, Uri, AutoResetEvent>(id,uri,evt));
            evt.WaitOne();
            return currentlyFetching[id];
        }

        void ThreadedDownloader(object o)
        {
            Tuple<string, Uri, AutoResetEvent> val = (Tuple<string, Uri, AutoResetEvent>)o;
            string id = val.Item1;
            Uri uri = val.Item2;
            AutoResetEvent evt = val.Item3;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            Stream stream = req.GetResponse().GetResponseStream();

            evt.Set();

            //long contentLength = req.GetResponse().ContentLength;

            byte[] data = new byte[4096];
            int read;
            while ((read = stream.Read(data, 0, data.Length)) > 0)
            {
                stream.Write(data, 0, read);
            }
            
        }
    }
}
