using System.IO;
using System.Text;
using System.Xml;
using System;
using SW.Helpers;

namespace SW.Services.Stamp
{
    internal class StampValidation : Validation
    {
        private string _xmlString;
        internal StampValidation(string url, string user, string password, string token) : base(url, user, password, token)
        {
        }
        internal void ValidaXML(string xmlString)
        {
            this._xmlString = xmlString;
            Validations();
        }
        internal void ValidaXML(byte[] xmlString)
        {
            this._xmlString = Encoding.UTF8.GetString(xmlString);
            Validations();
        }
        private void Validations()
        {
            try
            {
                if (!string.IsNullOrEmpty(_xmlString))
                {
                    ValidateEncoding();
                }else
                {
                    throw new ServicesException("XML esta vacio");
                }
            }
            catch (XmlException ex)
            {
                throw new ServicesException("No es un XML Valido "+ ex.Message);
            }
        }
        private void ValidateEncoding()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(new MemoryStream(Encoding.UTF8.GetBytes(_xmlString)));
            }
            catch (Exception)
            {
                throw new ServicesException("XML no tiene codificacion UTF-8");
            }
        }       
    }
}