﻿namespace SW.Services.Stamp
{
    public class StampV4 : BaseStampV4
    {
        public StampV4(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "stamp", proxy, proxyPort)
        {
        }
        public StampV4(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "stamp", proxy, proxyPort)
        {
        }
    }
}
