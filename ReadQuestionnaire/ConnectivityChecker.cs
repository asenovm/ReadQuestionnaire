using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Read
{
    public class ConnectivityChecker
    {

        private const int TIMEOUT_REQUEST = 750;

        public bool CanConnectTo(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = TIMEOUT_REQUEST;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
