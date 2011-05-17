using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

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
                    string postdata = "return_url=&login=altmind&password=";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(PP_URI_LOGIN);
                    req.Method = "POST";
                    byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
                    req.ContentType = "application/x-www-form-urlencoded";

                    req.ContentLength = byteArray.Length;
                    req.GetRequestStream().Write(byteArray, 0, byteArray.Length);
                    WebResponse res = req.GetResponse();
                    MessageBox.Show(res.Headers["Set-Cookie"]);
                    Stream stream = res.GetResponseStream();

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
