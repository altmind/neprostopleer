using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace neprostopleer.Cores
{
    class CoreProstopleerWebServices
    {
        string _cookie = null;

        private const string PP_URI_LOGIN = "http://prostopleer.ru/login";

        public void InitializeWebServices()
        {
            try
            {
                if (_cookie == null)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(PP_URI_LOGIN);
                    Stream stream = req.GetResponse().GetResponseStream();

                    byte[] data = new byte[4096];
                    int read;
                    while ((read = stream.Read(data, 0, data.Length)) > 0)
                    {
                        stream.Write(data, 0, read);
                    }
                }
            }
            catch (Exception e)
            {
                Program.logging.processException(e);
                _cookie = null;
                throw e;
            }
        }

        public Uri getUriForTrackId(string name)
        {
            if (_cookie == null)
                InitializeWebServices();
            return new Uri("http://ya.ru");
        }

    }
}
