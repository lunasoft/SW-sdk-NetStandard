using System;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Xml;
using System.Xml.Xsl;

namespace Test_SW.Helpers
{
    public static class SignTools
    {
        static Random randomNumber = new Random(1);
        public static string SigXml(string xml, byte[] pfx, string password, bool isRetention=false)
        {
            xml = RemoverCaracteresInvalidosXml(xml);
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            if (isRetention)
            {
                doc.DocumentElement.SetAttribute("FechaExp", DateTime.Now.AddHours(-12).ToString("s"));
            }
            else
            {
                doc.DocumentElement.SetAttribute("Serie", "SW-Sdk-NetStandard");
                doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-12).ToString("s"));
                doc.DocumentElement.SetAttribute("Folio", Guid.NewGuid().ToString());
            }
            // Guardar cambios
            xml = doc.OuterXml;
            // Definir ruta XSLT según tipo
            string xsltPath = isRetention
                ? "Retention20/retencion20.xslt"
                : "cadenaoriginal_4_0.xslt";

            return SignGeneric(pfx, password, xml, xsltPath);
        }
        public static X509Certificate2 GetCertificateValues(XmlDocument doc, byte[] pfx, string password)
        {
            var x509Certificate = new X509Certificate2(
            pfx, password,
            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
            //Set values Certificate
            doc.DocumentElement.SetAttribute("NoCertificado", CertificateNumber(x509Certificate));
            doc.DocumentElement.SetAttribute("Certificado", Convert.ToBase64String(x509Certificate.GetRawCertData()));

            return x509Certificate;
        }
        public static string SignGeneric(byte[] certificatePfx, string password, string xml, string xsltPath) 
        {
            xml = RemoverCaracteresInvalidosXml(xml);
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            //Get Certificates Attributes
            var cert = GetCertificateValues(doc, certificatePfx, password);
            //Get Original String
            string originalString = GetOriginalString(doc.OuterXml, xsltPath);
            //Set sing
            string sello = GetSignature(password, certificatePfx, originalString, "SHA256");
            doc.DocumentElement.SetAttribute("Sello", sello);

            return RemoverCaracteresInvalidosXml(doc.OuterXml);
        }
        public static string GetOriginalString(string strXml, string xsltPath)
        {
            try
            {
                var xslt = new XslCompiledTransform();
                var settings = new XsltSettings(true, true);
                var resolver = new XmlUrlResolver();
                xslt.Load($"Resources/XSLT/{xsltPath}", settings, resolver);
                using var stringWriter = new StringWriter();
                using var xmlReader = XmlReader.Create(new StringReader(strXml));
                xslt.Transform(xmlReader, null, stringWriter);

                return stringWriter.ToString()
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Replace("\t", "")
                    .Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("El XML proporcionado no es válido.", ex);
            }
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
            xmlInvoice = xmlInvoice.Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", @"<?xml version=""1.0"" encoding=""utf-8""?>").Trim();
            xmlInvoice = xmlInvoice.Replace("﻿", "");
            xmlInvoice = xmlInvoice.Replace(@"
", "");
            xmlInvoice = Regex.Replace(xmlInvoice, @"\s+", " ");
            xmlInvoice = xmlInvoice.Replace("> ", ">");
            xmlInvoice = xmlInvoice.Replace(" />", "/>");
            return xmlInvoice;
        }
    }
}
