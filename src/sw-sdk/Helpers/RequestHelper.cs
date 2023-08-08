using SW.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SW.Helpers
{
    internal class RequestHelper
    {
        internal static string NormalizeBaseUrl(string url)
        {
            return !url.EndsWith("/") ? url + "/" : url;
        }
        internal static void SetupProxy(string proxy, int port, ref HttpWebRequest request)
        {
            if (!string.IsNullOrEmpty(proxy))
            {
                WebProxy myProxy = new WebProxy(proxy, port);
                request.Proxy = myProxy;
            }
        }
        internal static Dictionary<string, string> GetHeaders(string Token)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + Token }
                };
            return headers;
        }
        internal static Dictionary<string, string> GetHeaders(string Token, string email, string customId, string[] extras)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + Token }
                };
            if (email != null && Validation.ValidateEmailStamp(email))
            {
                headers.Add("email", email);
            }
            if (customId != null)
            {
                Validation.ValidateCustomId(customId);
                headers.Add("customId", customId.Length > 100 ? customId.HashTo256() : customId);
            }
            if (extras != null)
            {
                headers.Add("extra", string.Join(",", extras));
            }
            return headers;
        }
        internal static HttpClientHandler ProxySettings(string proxy, int proxyPort)
        {
            if (!string.IsNullOrEmpty(proxy))
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = new WebProxy(string.Format("{0}:{1}", proxy,proxyPort), false),
                    UseProxy = true
                };
                return httpClientHandler;
            }
            else
            {
                return new HttpClientHandler();
            }
        }
        internal static void AddFileToRequest(byte[] file, ref HttpWebRequest request)
        {
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");

            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            Stream memStream = new System.IO.MemoryStream();
            
            var boundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" +
                                                                    boundary + "\r\n");
            var endBoundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" +
                                                                        boundary + "--");
            string formDataTemplate = "\r\n--" + boundary +
                                        "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
            string headerTemplate =
                 "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: application/octet-stream\r\n\r\n";

            memStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            var header = string.Format(headerTemplate, "xml", "xml");
            var headerBytes = System.Text.Encoding.UTF8.GetBytes(header);

            memStream.Write(headerBytes, 0, headerBytes.Length);

            using (var fileStream = new MemoryStream(file))
            {
                var buffer = new byte[1024];
                var bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
            }

            memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            request.ContentLength = memStream.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            }
        }
    }
}
