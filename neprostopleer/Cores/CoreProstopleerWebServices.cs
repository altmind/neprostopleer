using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using neprostopleer.Util;
using neprostopleer.Entities.WS;

namespace neprostopleer.Cores
{
    class CoreProstopleerWebServices
    {
        private string sid
        {
            get;
            set;
        }
        private string link
        {
            get;
            set;
        }
        private string login
        {
            get;
            set;
        }
        private CookieContainer cookieJar { get; set; }

        private const string PP_BASE = "http://prostopleer.com";
        private const string PP_URI_MAIN = PP_BASE;
        private const string PP_URI_LOGIN = PP_BASE + "/login";
        private const string PP_URI_GET_URL = PP_BASE + "/site_api/files/get_url";

        public void InitializeWebServices()
        {
            try
            {
                if (cookieJar == null)
                {
                    cookieJar = new CookieContainer();
                    string postdata = "return_url=&login=&password=";

                    HttpWebRequest req_main = (HttpWebRequest)WebRequest.Create(PP_URI_MAIN);
                    req_main.Method = "GET";
                    req_main.CookieContainer = cookieJar;
                    HttpWebResponse res_main = (HttpWebResponse)req_main.GetResponse();
                    Behavior.Assert((((int)res_main.StatusCode) % 100) < 4, "Error code " + res_main.StatusCode + " while fetching main page on getting sid");

                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(PP_URI_LOGIN);
                    req.Method = "POST";
                    req.CookieContainer = cookieJar;
                    req.Accept = "application/json, text/javascript, */*";
                    req.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    req.ContentType = "application/x-www-form-urlencoded";

                    Stream requestStream = req.GetRequestStream();
                    byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
                    requestStream.Write(byteArray, 0, byteArray.Length);
                    requestStream.Close();

                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Behavior.Assert((((int)res.StatusCode) % 100) < 4, "Error code " + res_main.StatusCode + " while logging in on getting sid");

                    foreach (Cookie cookie in cookieJar.GetCookies(req.RequestUri))
                    {
                        if ("SID".Equals(cookie.Name))
                        {
                            sid = cookie.Value;
                        }
                        else if ("link".Equals(cookie.Name))
                        {
                            link = cookie.Value;
                        }
                    }
                    Behavior.Assert(!String.IsNullOrWhiteSpace(sid), "Got empty sid. Login credentials incorrect? ");
                    Behavior.Assert(!String.IsNullOrWhiteSpace(link), "Got empty link");

                    Stream responseStream = res.GetResponseStream();
                    //StreamReader responseReader = new StreamReader(responseStream);
                    //String jsonResult = responseReader.ReadToEnd();

                    LoginResponse loginResponse = Program.binder.Unmarshal<LoginResponse>(responseStream);
                    Behavior.Assert(loginResponse.success, "Login unsuccessful");
                    Behavior.Assert(!String.IsNullOrWhiteSpace(loginResponse.login), "Login empty");

                }
            }
            catch (Exception e)
            {
                Program.logging.processException(e);
                cookieJar = null;
                login = null;
            }
        }

        public Uri getUriForTrackId(string name)
        {
            if (cookieJar == null)
                InitializeWebServices();

            string postdata = "action=play&id=" + name;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(PP_URI_GET_URL);
            req.Method = "POST";
            req.CookieContainer = cookieJar;
            req.Accept = "application/json, text/javascript, */*";
            req.Headers.Add("X-Requested-With", "XMLHttpRequest");
            req.ContentType = "application/x-www-form-urlencoded";

            Stream requestStream = req.GetRequestStream();
            byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Behavior.Assert((((int)res.StatusCode) % 100) < 4, "Error code " + res.StatusCode + " while getting track_url");
            GetUrlResponse getUrlResponse = Program.binder.Unmarshal<GetUrlResponse>(res.GetResponseStream());
            Behavior.Assert(getUrlResponse.success, "getUrlResponse Unsuccessful");
            return new Uri(getUrlResponse.track_link);
        }

    }
}
