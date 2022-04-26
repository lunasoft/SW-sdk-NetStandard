using System;
using System.IO;

namespace Test_SW.Helpers
{
    class BuildSettings
    {
        public string Url = "http://services.test.sw.com.mx";
        public string User = Environment.GetEnvironmentVariable("SdkTestCFDI40_User");
        public string Password = Environment.GetEnvironmentVariable("SdkTestCFDI40_Password");
        public string Pfx = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.pfx"));
        public string PfxPassword = "swpass";
        public string Token = Environment.GetEnvironmentVariable("SdkTestCFDI40_Token");
    }
}
