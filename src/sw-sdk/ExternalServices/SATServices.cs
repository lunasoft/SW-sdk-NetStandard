using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ExternalServices
{
    public class SATServices
    {
        private string _url;
        public string Url
        {
            get { return _url; }
        }

        public SATServices(string url)
        {
            _url = url; ;
        }

        public BasicHttpBinding GetBinding(int receiveTimeoutInSeconds)
        {
            var myBinding = new BasicHttpBinding();
            myBinding.Security.Mode = Url.StartsWith("https") ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.None;
            myBinding.ReceiveTimeout = new TimeSpan(0, 0, receiveTimeoutInSeconds);
            myBinding.SendTimeout = new TimeSpan(0, 0, receiveTimeoutInSeconds);
            myBinding.OpenTimeout = new TimeSpan(0, 0, receiveTimeoutInSeconds);
            myBinding.CloseTimeout = new TimeSpan(0, 0, receiveTimeoutInSeconds);
            myBinding.MaxReceivedMessageSize = 2147483647;
            myBinding.BypassProxyOnLocal = true;
            myBinding.UseDefaultWebProxy = true;
            return myBinding;
        }
    }
}
