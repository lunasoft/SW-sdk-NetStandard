using System;
using System.IO;
using System.Xml;
using System.Text;
using sw_cadenaoriginal;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Test_SW.Helpers
{
    public static class SignTools
    {
        static Random randomNumber = new Random(1);

        public static string GetXml(string fileName, string pfx, string password)
        {
            string xml = SignTools.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(fileName)));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-12).ToString("s"));
            doc.DocumentElement.SetAttribute("Folio", DateTime.Now.Ticks.ToString() + randomNumber.Next(100));
            xml = doc.OuterXml;
            xml = SellarCFDI(Convert.FromBase64String(pfx), password, xml);
            return xml;
        }

        public static string GetJson(string fileName)
        {
            string xml = SignTools.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(fileName)));
            var json = JObject.Parse(xml);
            json["Fecha"] = DateTime.Now.AddHours(-12).ToString("s");
            json["Folio"] = Guid.NewGuid().ToString();
            return json.ToString();
        }

        private static string SellarCFDI(byte[] certificatePfx, string password, string xml)
        {
            X509Certificate2 x509Certificate = new X509Certificate2(certificatePfx, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            //Set values Certificate
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("NoCertificado", CertificateNumber(x509Certificate));
            doc.DocumentElement.SetAttribute("Certificado", Convert.ToBase64String(x509Certificate.GetRawCertData()));
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }

            //Get original string
            string originalString = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            
            //Sign Document
            var signResult = GetSignature(password, certificatePfx, originalString, "SHA256");
            
            //Set Values Signature
            doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Sello", signResult);

            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }

            return xml;
        }

        private static string GetSignature(string password, byte[] pfx, string strToSign, string algorithm = "SHA1")
        {
            var signData = string.Empty;
            RSACryptoServiceProvider rsa = default(RSACryptoServiceProvider);
            byte[] signatureBytes = default(byte[]);
            X509Certificate2 certX509 = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            rsa = new RSACryptoServiceProvider();
            RSAKeyHelper.FromXmlString(rsa, RSAKeyHelper.ToXmlString(certX509.GetRSAPrivateKey(), true));
            byte[] data = Encoding.UTF8.GetBytes(strToSign);

            signatureBytes = rsa.SignData(data, CryptoConfig.MapNameToOID(algorithm));
            return Convert.ToBase64String(signatureBytes);
        }

        private static string CertificateNumber(X509Certificate2 cert)
        {
            string hexadecimalString = cert.SerialNumber;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexadecimalString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexadecimalString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        public static string RemoverCaracteresInvalidosXml(string xmlInvoice)
        {
            xmlInvoice = xmlInvoice.Replace("\r\n", "");
            xmlInvoice = xmlInvoice.Replace("\r", "");
            xmlInvoice = xmlInvoice.Replace("\n", "");
            xmlInvoice = xmlInvoice.Replace("﻿", "");
            xmlInvoice = xmlInvoice.Replace(@"
", "");
            return xmlInvoice;
        }
    }
}
