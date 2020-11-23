using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace TopitUp
{
    public class Web
    {

        int _timeout = 10000;
        int _ignorelicenselevel = 0;
        string _confirmcustomer = "";

        public Web(int TimeOut)
        {
            _timeout = TimeOut;
        }

        public Web(int TimeOut, int IgnoreLicenseLevel, string ConfirmCustomer)
        {
            _timeout = TimeOut;
            _ignorelicenselevel = IgnoreLicenseLevel;
            _confirmcustomer = ConfirmCustomer;
        }

        public string GetURLCustom(String uri)
        {

            string strResp = string.Empty;
            string errResp = string.Empty;

            String hash_dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
            String hash = Util.encrypt_blowfish(hash_dtm, Util.system_uid);

            string hasQuery = uri.Contains("?") ? "&" : "?";
            uri = uri + hasQuery + "ghash=" + Util.CalculateMD5Hash(globalSettings.license_code) + "-" + hash_dtm;

            try
            {

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                request.Method = @"GET";
                request.ContentType = @"text/xml";
                request.KeepAlive = false;
                request.Proxy = null;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                request.Timeout = _timeout;

                request.Headers.Add("license", globalSettings.license_code);
                request.Headers.Add("posuser", globalSettings.pos_user_id);
                request.Headers.Add("ignore", _ignorelicenselevel.ToString());
                request.Headers.Add("device", "pc");
                request.Headers.Add("hash", hash);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (!_confirmcustomer.Equals(""))
                {
                    if (!_confirmcustomer.Equals(response.GetResponseHeader("cid")))
                    {
                        response.Close();
                        return strResp = "<webreqerr>Network Data Issue, Try Again Later</webreqerr>";
                    }
                }


                using (Stream respStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(respStream, Encoding.UTF8);
                    strResp = rdr.ReadToEnd();
                    rdr.Close();
                }

                response.Close();

            }
            catch (TimeoutException wx)
            {
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (WebException wx)
            {
                Util.ConnectionStatus = 1;
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (Exception wx)
            {
                Util.ConnectionStatus = 1;
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            finally
            {
                Util.ConnectionStatus = 2;
            }


            return strResp;

        }


        // callback used to validate the certificate in an SSL conversation
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = false;
            if (cert.Subject.ToUpper().Contains("YourServerName"))
            {
                result = true;
            }

            return result;
        }




        public string GetURL(String uri)
        {

            string strResp = string.Empty;
            string errResp = string.Empty;

            String hash_dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
            String hash = Util.encrypt_blowfish(hash_dtm, Util.system_uid);

            string hasQuery = uri.Contains("?") ? "&" : "?";
            uri = uri + hasQuery + "ghash=" + Util.CalculateMD5Hash(globalSettings.license_code) + "-" + hash_dtm;

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + globalSettings.svr_ip + ":" + globalSettings.svr_port + uri);

                request.Method = @"GET";
                request.ContentType = @"text/xml";
                request.KeepAlive = false;
                request.Proxy = null;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                request.Timeout = _timeout;

                request.Headers.Add("license", globalSettings.license_code);
                request.Headers.Add("posuser", globalSettings.pos_user_id);
                request.Headers.Add("ignore", _ignorelicenselevel.ToString());
                request.Headers.Add("device", "pc");
                request.Headers.Add("hash", hash);

                HttpWebResponse response = (HttpWebResponse) request.GetResponse();

                using (Stream respStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(respStream, Encoding.UTF8);
                    strResp = rdr.ReadToEnd();
                    rdr.Close();
                }

                response.Close();

            }
            catch (TimeoutException wx)
            {
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (WebException wx)
            {
                Util.ConnectionStatus = 1;
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (Exception wx)
            {
                Util.ConnectionStatus = 1;
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            finally
            {
                Util.ConnectionStatus = 2;
            }


            return strResp;

        }


        public string PostData(String uri, String postData)
        {

            string strResp = string.Empty;
            string errResp = string.Empty;

            String hash_dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
            String hash = Util.encrypt_blowfish(hash_dtm, Util.system_uid);

            string hasQuery = uri.Contains("?") ? "&" : "?";
            uri = uri + hasQuery + "ghash=" + Util.CalculateMD5Hash(globalSettings.license_code) + "-" + hash_dtm;

            var data = Encoding.ASCII.GetBytes(postData);

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + globalSettings.svr_ip + ":" + globalSettings.svr_port + uri);

                request.Method = @"POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.KeepAlive = false;
                request.Proxy = null;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                request.Timeout = _timeout;

                request.Headers.Add("license", globalSettings.license_code);
                request.Headers.Add("posuser", globalSettings.pos_user_id);
                request.Headers.Add("ignore", _ignorelicenselevel.ToString());
                request.Headers.Add("device", "pc");
                request.Headers.Add("hash", hash);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream respStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(respStream, Encoding.UTF8);
                    strResp = rdr.ReadToEnd();
                    rdr.Close();
                }

                response.Close();

            }
            catch (TimeoutException wx)
            {
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (WebException wx)
            {
                Util.ConnectionStatus = 1;
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (Exception wx)
            {
                Util.ConnectionStatus = 1;
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            finally
            {
                Util.ConnectionStatus = 2;
            }


            return strResp;

        }






        public string GetURLSync(String uri)
        {
            string strResp = string.Empty;

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + globalSettings.svr_ip + ":" + globalSettings.sync_port + uri);

                request.Method = @"GET";
                request.ContentType = @"text/xml";
                request.KeepAlive = false;
                request.Proxy = null;
                request.Timeout = _timeout;

                request.Headers.Add("license", globalSettings.license_code);
                request.Headers.Add("device", "pc");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream respStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(respStream, Encoding.UTF8);
                    strResp = rdr.ReadToEnd();
                    rdr.Close();
                }

                response.Close();

            }
            catch (TimeoutException wx)
            {
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (WebException wx)
            {
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }
            catch (Exception wx)
            {
                strResp = "<webreqerr>" + wx.Message + "</webreqerr>";
            }

            return strResp;

        }


        public bool GetURLSoftwareUpdate(String uri, String destination)
        {
            bool success = false;

            Stream responseStream = null;
            FileStream fileStream = null;
            System.Net.WebResponse response = null;

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + globalSettings.svr_ip + ":" + globalSettings.sync_port + uri);

                //Console.WriteLine("http://" + globalSettings.svr_ip + ":" + globalSettings.sync_port + uri);

                request.Method = @"GET";
                request.KeepAlive = false;
                request.Proxy = null;
                request.Timeout = _timeout;

                request.Headers.Add("license", globalSettings.license_code);
                request.Headers.Add("device", "pc");

                response = (HttpWebResponse)request.GetResponse();

                responseStream = response.GetResponseStream();

                fileStream = File.Open(destination, FileMode.Create, FileAccess.Write, FileShare.None);

                int maxRead = 10240;
                byte[] buffer = new byte[maxRead];
                int bytesRead = 0;
                int totalBytesRead = 0;

                // loop until no data is returned
                while ((bytesRead = responseStream.Read(buffer, 0, maxRead)) > 0)
                {
                    totalBytesRead += bytesRead;
                    fileStream.Write(buffer, 0, bytesRead);
                }

                // we got to this point with no exception. Ok.
                success = true;

            }
            catch 
            {

                success = false;
            }
            finally 
            {
                if (null != responseStream)
                    responseStream.Close();
                if (null != response)
                    response.Close();
                if (null != fileStream)
                    fileStream.Close();
            }

            if (!success && File.Exists(destination))
            {
                File.Delete(destination);
            }

            return success;

        }


    }
}
