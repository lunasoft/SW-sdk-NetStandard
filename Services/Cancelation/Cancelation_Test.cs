using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using SW.Services.Cancelation;
using SW.Helpers;
using Test_SW.Helpers;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;

namespace Test_SW.Services.Cancelation_Test_45
{
    [TestClass]
    public class Cancelation_Test_45
    {
        private const string uuid = "c2c57c10-45a2-4f1c-8f7b-c660a107ffa2";
        [TestMethod]
        public void Cancelation_Test_45_CancelationByCSD()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation("http://services.test.sw.com.mx", "demo", "123456789");
            //Al igual que el objeto de stamp, se indica url del ambiente al cual apuntara y credenciales de acceso o token.
            string csdBase64 = build.Cer;//.Cer en Base64
            string keyBase64 = build.Key;//.Key en Base64
            string password = build.CerPassword;//password del CSD
            string rfc = "LAN8507268IA";
            string uuid = "7028573d-5a18-4331-8285-cd97b156c901";
            var response = cancelation.CancelarByCSD(csdBase64, keyBase64, rfc, password, uuid);
            if (response.status != "error")
            {
                //acuse de cancelación
                Console.WriteLine(response.data.acuse);
            }
            else
            {
                Console.WriteLine(response.message);
                Console.WriteLine(response.messageDetail);
            }
            Assert.IsTrue(response.data.acuse != null && response.status == "success");
        }
        [TestMethod]
        public void Cancelation_Test_45_CancelationByRfcUuid()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = cancelation.CancelarByRfcUuid(build.Rfc, uuid);
            Assert.IsTrue(response.data.acuse != null && response.status == "success");
        }

        [TestMethod]
        public void Cancelation_Test_45_CancelationByPFX()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            CancelationResponse response = cancelation.CancelarByPFX(build.Pfx, build.Rfc, build.CerPassword, uuid);
            Assert.IsTrue(response != null && response.status == "success");
        }
        
        [TestMethod]
        [Ignore]
        public void Cancelation_Test_45_CancelationByXML()
        {
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = cancelation.CancelarByXML(build.Acuse);
            Assert.IsTrue(response != null && response.status == "success");
        }
        [TestMethod]
        public void Cancelation_Test_45_ValidateParameters()
        {
            var resultExpect = "Son necesarios el .Cer y el .Key en formato B64";
            var build = new BuildSettings();
            Cancelation cancelation = new Cancelation(build.Url, build.User, build.Password);
            var response = cancelation.CancelarByCSD(build.Cer, build.Key, build.Rfc, build.CerPassword, "");
            Assert.IsTrue(response.messageDetail.Contains((string)resultExpect));
        }
    }
}